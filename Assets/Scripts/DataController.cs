using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

public class DataController : MonoBehaviour
{
    // 싱글톤
    private static DataController instance;
    public static DataController GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<DataController>();

            if (instance == null)
            {
                GameObject container = new GameObject("DataController");
                instance = container.AddComponent<DataController>();
            }
            DontDestroyOnLoad(instance);
        }
        return instance;
    }

    public ItemButton[] itemButtons; // 차후에 사용할 예정
    public GameObject namePanel;
    public GameObject evaluatePanel;

    private int totalGold = 0; // 총 소비한 재화

    private int m_gold = 0; // 총 무료 재화

    private int m_goldPerClick = 0; // 총 클릭 당 무료 재화

    private int payGoods = 0; // 총 유료 재화

    public string currentname; // 이름 입력

    public List<string> Names = new List<string>(); // 이름 담을 배열
    public int nameNumber; // 이름 배열 길이

    public float playTime; // 플레이타임

    public int[] year; //몇 대 총장이 몇 년 까지 했는지
    public int[] semester; // 몇 대 총장이 몇 학기 까지 했는지

    private int[] tempYear;
    private int[] tempSemester;

    public int currentYear; // 현재 년도

    private void Awake()
    {
        m_gold = PlayerPrefs.GetInt("Gold"); // 무료 재화 로컬 서버에서 불러오기
        m_goldPerClick = PlayerPrefs.GetInt("GoldPerClick", 1); // 클릭 당 무료 재화 로컬 서버에서 불러오기
        totalGold = PlayerPrefs.GetInt("TotalGold");
        payGoods = PlayerPrefs.GetInt("payGoods");

        itemButtons = FindObjectsOfType<ItemButton>();

        namePanel.SetActive(true); // 첫 이름 입력
    }

    private void Start()
    {
        m_gold += GetGoldPerSec() * timeAfterLastPlay;
        totalGold += GetGoldPerSec() * timeAfterLastPlay;
        InvokeRepeating("UpdateLastPlayDate", 0f, 5f);//함수 5초마다 실행

        year = new int[nameNumber + 1]; // 몇 대 총장이 몇 년 까지 했는지
        semester = new int[nameNumber + 1]; // 몇 대 총장이 몇 학기 까지 했는지

        currentYear = year[nameNumber]; // 현재 연도 저장
    }

    private void Update()
    {
        playTime += Time.deltaTime; // 플레이타임 저장


        CheckYear(); // 해가 바뀌는지 확인
    }

    DateTime GetLastPlayDate() // 마지막으로 플레이했던 시간 불러옴
    {
        if (!PlayerPrefs.HasKey("Time"))
        {
            return DateTime.Now;
        }
        string timeBinaryInString = PlayerPrefs.GetString("Time");
        long timeBinaryInLong = Convert.ToInt64(timeBinaryInString);

        return DateTime.FromBinary(timeBinaryInLong);
    }

    void UpdateLastPlayDate() // 마지막으로 게임을 플레이한 시점 문장으로 저장
    {
        PlayerPrefs.SetString("Time", DateTime.Now.ToBinary().ToString());
    }

    void OnApplicationQuit() // 프로그램 종료시 바로 실행
    {
        UpdateLastPlayDate();
    }

    public int timeAfterLastPlay // 마지막 플레이 시점에서 몇초가 지났는지
    {
        get
        {
            DateTime currentTime = DateTime.Now;
            DateTime lastPlayDate = GetLastPlayDate();

            return (int)currentTime.Subtract(lastPlayDate).TotalSeconds;
        }
    }

    // 유료 재화 로컬 서버 저장
    public void SetPayGoods(int newPay)
    {
        payGoods = newPay;
        PlayerPrefs.SetInt("payGoods", payGoods);
    }

    // 유료 재화 추가 함수
    public void AddPayGoods(int newPay)
    {
        payGoods += newPay;
        SetPayGoods(payGoods);
    }

    public void SubPayGoods(int newPay)
    {
        payGoods -= newPay;
        SetPayGoods(payGoods);
    }

    // 유료 재화 불러오는 함수
    public int GetPayGoods()
    {
        return payGoods;
    }

    public int GetTotalGold()
    {
        return totalGold;
    }

    // 누적 재화 로컬 서버 저장
    public void SetTotalGold(int newGold)
    {
        totalGold = newGold;
        PlayerPrefs.SetInt("TotalGold", totalGold);
    }

    // 누적 재화 덧셈
    public void AddTotalGold(int newGold)
    {
        totalGold += newGold;
        SetTotalGold(totalGold);
    }

    // 무료 재화 로컬 서버 저장
    public void SetGold(int newGold)
    {
        m_gold = newGold;
        PlayerPrefs.SetInt("Gold", m_gold);
    }

    // 무료 재화 추가 함수
    public void AddGold(int newGold)
    {
        m_gold += newGold;
        SetGold(m_gold);
    }

    // 무료 재화 차감 함수
    public void SubGold(int newGold)
    {
        m_gold -= newGold;
        SetGold(m_gold);
    }

    // 무료 재화 불러오는 함수
    public int GetGold()
    {
        return m_gold;
    }

    // 클릭 당 무료 재화 가져오기
    public int GetGoldPerClick()
    {
        return m_goldPerClick;
    }

    // 클릭 당 무료 재화 저장
    public void SetGoldPerClick(int newGoldPerClick)
    {
        m_goldPerClick = newGoldPerClick;
        PlayerPrefs.SetInt("GoldPerClick", m_goldPerClick);
    }

    // 클릭 당 무료 재화 증가
    public void AddGoldPerClick(int newGoldPerClick)
    {
        m_goldPerClick += newGoldPerClick;
        SetGoldPerClick(m_goldPerClick);
    }

    // UpgradeButton 변수들 PlayerPrefs에서 불러오기
    public void LoadUpgradeButton(UpgradeButton upgradeButton)
    {
        string key = upgradeButton.buildingName;

        upgradeButton.goldByUpgrade = PlayerPrefs.GetInt(key + "_goldByUpgrade", upgradeButton.startGoldByUpgrade);
        upgradeButton.buildLevels = PlayerPrefs.GetInt(key + "_upgradeLevel", 0);
    }

    // UpgradeButton 변수들 PlayerPrefs에 저장
    public void SaveUpgradeButton(UpgradeButton upgradeButton)
    {
        string key = upgradeButton.buildingName;

        PlayerPrefs.SetInt(key + "_goldByUpgrade", upgradeButton.startGoldByUpgrade);
        PlayerPrefs.SetInt(key + "_upgradeLevel", upgradeButton.buildLevels);
    }

    // 이름 저장 함수
    public void SaveName(NameManager nameManager)
    {
        PlayerPrefs.SetString("Name", nameManager.input);
        currentname = PlayerPrefs.GetString("Name");
        namePanel.SetActive(false);

        Names.Add(currentname);

        tempYear = new int[nameNumber];
        tempSemester = new int[nameNumber];

        tempYear = year;
        tempSemester = semester;

        nameNumber++;

        year = new int[nameNumber]; // 몇 대 총장이 몇 년 까지 했는지
        semester = new int[nameNumber]; // 몇 대 총장이 몇 학기 까지 했는지

        for (int i = 0; i < nameNumber - 1; i++)
        {
            year[i] = tempYear[i];
            semester[i] = tempSemester[i];
        }
        playTime = 0;

        for (int i = 0; i < nameNumber; i++)
            Debug.Log(Names[i]);

    }

    // 아이템 관련 함수들은 차후에 사용할 예정
    public void LoadItemButton(ItemButton itemButton)
    {
        string key = itemButton.itemName;
        itemButton.level = PlayerPrefs.GetInt(key + "_itemLevel");
        itemButton.currentCost = PlayerPrefs.GetInt(key + "_cost", itemButton.startCurrentCost);
        itemButton.goldPerSec = PlayerPrefs.GetInt(key + "_goldPerSec");

        if (PlayerPrefs.GetInt(key + "_isPurchase") == 1)
        {
            itemButton.isPurchase = true;
        }

        else
        {
            itemButton.isPurchase = false;
        }
    }

    public void SaveItemButton(ItemButton itemButton)
    {
        string key = itemButton.itemName;
        PlayerPrefs.SetInt(key + "_itemLevel", itemButton.level);
        PlayerPrefs.SetInt(key + "_cost", itemButton.startCurrentCost);
        PlayerPrefs.SetInt(key + "_goldPerSec", itemButton.goldPerSec);

        if (itemButton.isPurchase == true)
        {
            PlayerPrefs.SetInt(key + "_isPurchase", 1);
        }
        else
        {
            PlayerPrefs.SetInt(key + "_isPurchase", 0);
        }
    }

    public void SaveAchievement(AchievementManager achievementManager)
    {
        for (int i = 0; i < achievementManager.achievementList.achievementsInfo.Length; i++)
        {
            if (achievementManager.achievementList.achievementsInfo[i].isAchieve == true)
            {
                PlayerPrefs.SetInt(achievementManager.achievementList.achievementsInfo[i].achievementName + "isAchieve", 1);
            }

            else
            {
                PlayerPrefs.SetInt(achievementManager.achievementList.achievementsInfo[i].achievementName + "isAchieve", 0);
            }
        }
    }

    public void LoadAchievement(AchievementManager achievementManager)
    {
        for (int i = 0; i < achievementManager.achievementList.achievementsInfo.Length; i++)
        {
            if (PlayerPrefs.GetInt(achievementManager.achievementList.achievementsInfo[i].achievementName + "isAchieve") == 1)
            {
                achievementManager.achievementList.achievementsInfo[i].isAchieve = true;
            }

            else
            {
                achievementManager.achievementList.achievementsInfo[i].isAchieve = false;
            }
        }
    }

    public int GetGoldPerSec() // 초당 돈 총합 구하기
    {
        int totalGoldPerSec = 0;

        for (int i = 0; i < itemButtons.Length; i++)
        {
            if (itemButtons[i].isPurchase == true)
                totalGoldPerSec += itemButtons[i].goldPerSec; // itemButtons 배열로 모든 itemButton의 초당수입 더하기
        }

        return totalGoldPerSec;
    }

    //연도가 바뀌는지 확인하는 코드
    public void CheckYear()
    {
        if (nameNumber > 0)
        {
            if (year[nameNumber - 1] != currentYear && year[nameNumber - 1] != 0)
            {
                evaluatePanel.SetActive(true);

                return;
            }

        }
    }

}

