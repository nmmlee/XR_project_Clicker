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
        }
        return instance;
    }

    private ItemButton[] itemButtons; // 차후에 사용할 예정
    public GameObject namePanel;

    private int m_gold = 0; // 총 무료 재화

    private int m_goldPerClick = 0; // 총 클릭 당 무료 재화

    private int payGoods = 0; // 총 유료 재화

    string currentname; // 이름 입력

    string[] currentName;
    int nameNumber = 0;

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


    void Awake()
    {
        m_gold = PlayerPrefs.GetInt("Gold"); // 무료 재화 로컬 서버에서 불러오기
        m_goldPerClick = PlayerPrefs.GetInt("GoldPerClick", 1); // 클릭 당 무료 재화 로컬 서버에서 불러오기

        itemButtons = FindObjectsOfType<ItemButton>();
    }

    private void Start()
    {
        m_gold += GetGoldPerSec() * timeAfterLastPlay;
        InvokeRepeating("UpdateLastPlayDate",0f,5f);//함수 5초마다 실행
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

    // 유료 재화 불러오는 함수
    public int GetPayGoods()
    {
        return payGoods;
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

        upgradeButton.level = PlayerPrefs.GetInt(key + "_level", 1);
        upgradeButton.goldByUpgrade = PlayerPrefs.GetInt(key + "_goldByUpgrade", upgradeButton.startGoldByUpgrade);
        upgradeButton.buildLevels = PlayerPrefs.GetInt(key + "_level", 0);
    }

    // UpgradeButton 변수들 PlayerPrefs에 저장
    public void SaveUpgradeButton(UpgradeButton upgradeButton) 
    {
        string key = upgradeButton.buildingName;

        PlayerPrefs.SetInt(key + "_level", upgradeButton.level);
        PlayerPrefs.SetInt(key + "_goldByUpgrade", upgradeButton.startGoldByUpgrade);
        PlayerPrefs.SetInt(key + "_level", upgradeButton.buildLevels);
    }

    // 이름 저장 함수
    public void SaveName(NameManager nameManager)
    {
        /*
        PlayerPrefs.SetString("Name", nameManager.input);
        currentname = PlayerPrefs.GetString("Name");
        Debug.Log(currentname);
        namePanel.SetActive(false);
        */

        PlayerPrefs.SetString(nameNumber.ToString() + "_Name", nameManager.input);
        currentName[nameNumber] = PlayerPrefs.GetString(nameNumber.ToString() + "_Name");
        Debug.Log(currentName[nameNumber]);
        namePanel.SetActive(false);

        nameNumber++;
    }



    // 아이템 관련 함수들은 차후에 사용할 예정
    public void LoadItemButton(ItemButton itemButton)
    {
        string key = itemButton.itemName;
        itemButton.level = PlayerPrefs.GetInt(key + "_level");
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
        PlayerPrefs.SetInt(key + "_level", itemButton.level);
        PlayerPrefs.SetInt(key + "_cost", itemButton.startCurrentCost);
        PlayerPrefs.SetInt(key + "_goldPerSec", itemButton.goldPerSec);

        if(itemButton.isPurchase == true)
        {
            PlayerPrefs.SetInt(key + "_isPurchase", 1);
        }
        else
        {
            PlayerPrefs.SetInt(key + "_isPurchase", 0);
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

}

