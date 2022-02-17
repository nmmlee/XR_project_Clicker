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

    private ItemButton[] itemButtons;


    private int m_gold = 0; // 총 골드

    private int m_goldPerClick = 0; // 총 클릭 당 골드
    DateTime GetLastPlayDate()//마지막으로 플레이했던 시간 불러옴
    {
        if (!PlayerPrefs.HasKey("Time"))
        {
            return DateTime.Now;
        }
        string timeBinaryInString = PlayerPrefs.GetString("Time");
        long timeBinaryInLong = Convert.ToInt64(timeBinaryInString);

        return DateTime.FromBinary(timeBinaryInLong);
    }

    void UpdateLastPlayDate()//마지막으로 게임을 플레이한 시점 문장으로 저장
    {
        PlayerPrefs.SetString("Time", DateTime.Now.ToBinary().ToString());
    }

    void OnApplicationQuit()//프로그램 종료시 바로 실행
    {
        UpdateLastPlayDate();
    }

    public int timeAfterLastPlay()//마지막 플레이 시점에서 몇초가 지났는지
    {
        DateTime currentTime = DateTime.Now;
        DateTime lastPlayDate = GetLastPlayDate();

        return (int)currentTime.Subtract(lastPlayDate).TotalSeconds;

    }


    void Awake()
    {
        m_gold = PlayerPrefs.GetInt("Gold");
        m_goldPerClick = PlayerPrefs.GetInt("GoldPerClick", 1);

        itemButtons = FindObjectsOfType<ItemButton>();
    }

    private void Start()
    {
        m_gold += GetGoldPerSec() * timeAfterLastPlay();
        InvokeRepeating("UpdateLastPlayDate",0f,5f);//함수 5초마다 실행
    }

    public void SetGold(int newGold) // 돈 저장
    {
        m_gold = newGold;
        PlayerPrefs.SetInt("Gold", m_gold);
    }

    public void AddGold(int newGold) // 돈 추가
    {
        m_gold += newGold;
        SetGold(m_gold);
    }

    public void SubGold(int newGold) // 돈 뺄셈
    {
        m_gold -= newGold;
        SetGold(m_gold);
    }

    public int GetGold() // 돈 가져오기
    {
        return m_gold;
    }

    public int GetGoldPerClick() // 클릭당 돈 가져오기
    {
        return m_goldPerClick;
    }

    public void SetGoldPerClick(int newGoldPerClick) // 클릭당 돈 저장
    {
        m_goldPerClick = newGoldPerClick;
        PlayerPrefs.SetInt("GoldPerClick", m_goldPerClick);
    }
    public void AddGoldPerClick(int newGoldPerClick) // 클릭당 수입 증가
    {
        m_goldPerClick += newGoldPerClick;
        SetGoldPerClick(m_goldPerClick);
    }

    public void LoadUpgradeButton(UpgradeButton upgradeButton) // UpgradeButton 변수들 PlayerPrefs에 불러오기
    {
        string key = upgradeButton.upgradeName;

        upgradeButton.level = PlayerPrefs.GetInt(key + "_level", 1);
        upgradeButton.goldByUpgrade = PlayerPrefs.GetInt(key + "_goldByUpgrade", upgradeButton.startGoldByUpgrade);
        upgradeButton.currentCost = PlayerPrefs.GetInt(key + "_cost", upgradeButton.startCurrentCost);
        upgradeButton.buildLevels = PlayerPrefs.GetInt(key + "_level", 0);
    }

    public void SaveUpgradeButton(UpgradeButton upgradeButton) // UpgradeButton 변수들 PlayerPrefs에 저장
    {
        string key = upgradeButton.upgradeName;

        PlayerPrefs.SetInt(key + "_level", upgradeButton.level);
        PlayerPrefs.SetInt(key + "_goldByUpgrade", upgradeButton.startGoldByUpgrade);
        PlayerPrefs.SetInt(key + "_cost", upgradeButton.currentCost);
        PlayerPrefs.SetInt(key + "_level", upgradeButton.buildLevels);
    }

    public void LoadItemButton(ItemButton itemButton)
    {
        string key = itemButton.itemName;
        itemButton.level = PlayerPrefs.GetInt(key + "_level");
        itemButton.currentCost = PlayerPrefs.GetInt(key + "_cost", itemButton.startCurrentCost);
        itemButton.goldPerSec = PlayerPrefs.GetInt(key + "_goldPerSec");

        if(PlayerPrefs.GetInt(key + "_isPurchase") == 1)
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

        for(int i = 0; i < itemButtons.Length; i++)
        {
            if(itemButtons[i].isPurchase==true)
                totalGoldPerSec += itemButtons[i].goldPerSec; // itemButtons 배열로 모든 itemButton의 초당수입 더하기
        }

        return totalGoldPerSec;
    }
}

