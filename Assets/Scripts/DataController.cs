using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

public class DataController : MonoBehaviour
{ 
    // �̱���
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


    private int m_gold = 0; // �� ���

    private int m_goldPerClick = 0; // �� Ŭ�� �� ���
    DateTime GetLastPlayDate()//���������� �÷����ߴ� �ð� �ҷ���
    {
        if (!PlayerPrefs.HasKey("Time"))
        {
            return DateTime.Now;
        }
        string timeBinaryInString = PlayerPrefs.GetString("Time");
        long timeBinaryInLong = Convert.ToInt64(timeBinaryInString);

        return DateTime.FromBinary(timeBinaryInLong);
    }

    void UpdateLastPlayDate()//���������� ������ �÷����� ���� �������� ����
    {
        PlayerPrefs.SetString("Time", DateTime.Now.ToBinary().ToString());
    }

    void OnApplicationQuit()//���α׷� ����� �ٷ� ����
    {
        UpdateLastPlayDate();
    }

    public int timeAfterLastPlay()//������ �÷��� �������� ���ʰ� ��������
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
        InvokeRepeating("UpdateLastPlayDate",0f,5f);//�Լ� 5�ʸ��� ����
    }

    public void SetGold(int newGold) // �� ����
    {
        m_gold = newGold;
        PlayerPrefs.SetInt("Gold", m_gold);
    }

    public void AddGold(int newGold) // �� �߰�
    {
        m_gold += newGold;
        SetGold(m_gold);
    }

    public void SubGold(int newGold) // �� ����
    {
        m_gold -= newGold;
        SetGold(m_gold);
    }

    public int GetGold() // �� ��������
    {
        return m_gold;
    }

    public int GetGoldPerClick() // Ŭ���� �� ��������
    {
        return m_goldPerClick;
    }

    public void SetGoldPerClick(int newGoldPerClick) // Ŭ���� �� ����
    {
        m_goldPerClick = newGoldPerClick;
        PlayerPrefs.SetInt("GoldPerClick", m_goldPerClick);
    }
    public void AddGoldPerClick(int newGoldPerClick) // Ŭ���� ���� ����
    {
        m_goldPerClick += newGoldPerClick;
        SetGoldPerClick(m_goldPerClick);
    }

    public void LoadUpgradeButton(UpgradeButton upgradeButton) // UpgradeButton ������ PlayerPrefs�� �ҷ�����
    {
        string key = upgradeButton.upgradeName;

        upgradeButton.level = PlayerPrefs.GetInt(key + "_level", 1);
        upgradeButton.goldByUpgrade = PlayerPrefs.GetInt(key + "_goldByUpgrade", upgradeButton.startGoldByUpgrade);
        upgradeButton.currentCost = PlayerPrefs.GetInt(key + "_cost", upgradeButton.startCurrentCost);
        upgradeButton.buildLevels = PlayerPrefs.GetInt(key + "_level", 0);
    }

    public void SaveUpgradeButton(UpgradeButton upgradeButton) // UpgradeButton ������ PlayerPrefs�� ����
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

    public int GetGoldPerSec() // �ʴ� �� ���� ���ϱ�
    {
        int totalGoldPerSec = 0;

        for(int i = 0; i < itemButtons.Length; i++)
        {
            if(itemButtons[i].isPurchase==true)
                totalGoldPerSec += itemButtons[i].goldPerSec; // itemButtons �迭�� ��� itemButton�� �ʴ���� ���ϱ�
        }

        return totalGoldPerSec;
    }
}

