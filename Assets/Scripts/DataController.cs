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

    private ItemButton[] itemButtons; // ���Ŀ� ����� ����
    public GameObject namePanel;

    private int m_gold = 0; // �� ���� ��ȭ

    private int m_goldPerClick = 0; // �� Ŭ�� �� ���� ��ȭ

    private int payGoods = 0; // �� ���� ��ȭ

    string currentname; // �̸� �Է�

    string[] currentName;
    int nameNumber = 0;

    DateTime GetLastPlayDate() // ���������� �÷����ߴ� �ð� �ҷ���
    {
        if (!PlayerPrefs.HasKey("Time"))
        {
            return DateTime.Now;
        }
        string timeBinaryInString = PlayerPrefs.GetString("Time");
        long timeBinaryInLong = Convert.ToInt64(timeBinaryInString);

        return DateTime.FromBinary(timeBinaryInLong);
    }

    void UpdateLastPlayDate() // ���������� ������ �÷����� ���� �������� ����
    {
        PlayerPrefs.SetString("Time", DateTime.Now.ToBinary().ToString());
    }

    void OnApplicationQuit() // ���α׷� ����� �ٷ� ����
    {
        UpdateLastPlayDate();
    }

    public int timeAfterLastPlay // ������ �÷��� �������� ���ʰ� ��������
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
        m_gold = PlayerPrefs.GetInt("Gold"); // ���� ��ȭ ���� �������� �ҷ�����
        m_goldPerClick = PlayerPrefs.GetInt("GoldPerClick", 1); // Ŭ�� �� ���� ��ȭ ���� �������� �ҷ�����

        itemButtons = FindObjectsOfType<ItemButton>();
    }

    private void Start()
    {
        m_gold += GetGoldPerSec() * timeAfterLastPlay;
        InvokeRepeating("UpdateLastPlayDate",0f,5f);//�Լ� 5�ʸ��� ����
    }

    // ���� ��ȭ ���� ���� ����
    public void SetPayGoods(int newPay)
    {
        payGoods = newPay;
        PlayerPrefs.SetInt("payGoods", payGoods);
    }

    // ���� ��ȭ �߰� �Լ�
    public void AddPayGoods(int newPay)
    {
        payGoods += newPay;
        SetPayGoods(payGoods);
    }

    // ���� ��ȭ �ҷ����� �Լ�
    public int GetPayGoods()
    {
        return payGoods;
    }

    // ���� ��ȭ ���� ���� ����
    public void SetGold(int newGold)
    {
        m_gold = newGold;
        PlayerPrefs.SetInt("Gold", m_gold);
    }

    // ���� ��ȭ �߰� �Լ�
    public void AddGold(int newGold)
    {
        m_gold += newGold;
        SetGold(m_gold);
    }

    // ���� ��ȭ ���� �Լ�
    public void SubGold(int newGold)
    {
        m_gold -= newGold;
        SetGold(m_gold);
    }

    // ���� ��ȭ �ҷ����� �Լ�
    public int GetGold() 
    {
        return m_gold;
    }

    // Ŭ�� �� ���� ��ȭ ��������
    public int GetGoldPerClick() 
    {
        return m_goldPerClick;
    }

    // Ŭ�� �� ���� ��ȭ ����
    public void SetGoldPerClick(int newGoldPerClick) 
    {
        m_goldPerClick = newGoldPerClick;
        PlayerPrefs.SetInt("GoldPerClick", m_goldPerClick);
    }

    // Ŭ�� �� ���� ��ȭ ����
    public void AddGoldPerClick(int newGoldPerClick) 
    {
        m_goldPerClick += newGoldPerClick;
        SetGoldPerClick(m_goldPerClick);
    }

    // UpgradeButton ������ PlayerPrefs���� �ҷ�����
    public void LoadUpgradeButton(UpgradeButton upgradeButton) 
    {
        string key = upgradeButton.buildingName;

        upgradeButton.level = PlayerPrefs.GetInt(key + "_level", 1);
        upgradeButton.goldByUpgrade = PlayerPrefs.GetInt(key + "_goldByUpgrade", upgradeButton.startGoldByUpgrade);
        upgradeButton.buildLevels = PlayerPrefs.GetInt(key + "_level", 0);
    }

    // UpgradeButton ������ PlayerPrefs�� ����
    public void SaveUpgradeButton(UpgradeButton upgradeButton) 
    {
        string key = upgradeButton.buildingName;

        PlayerPrefs.SetInt(key + "_level", upgradeButton.level);
        PlayerPrefs.SetInt(key + "_goldByUpgrade", upgradeButton.startGoldByUpgrade);
        PlayerPrefs.SetInt(key + "_level", upgradeButton.buildLevels);
    }

    // �̸� ���� �Լ�
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



    // ������ ���� �Լ����� ���Ŀ� ����� ����
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

    public int GetGoldPerSec() // �ʴ� �� ���� ���ϱ�
    {
        int totalGoldPerSec = 0;

        for (int i = 0; i < itemButtons.Length; i++)
        {
            if (itemButtons[i].isPurchase == true)
                totalGoldPerSec += itemButtons[i].goldPerSec; // itemButtons �迭�� ��� itemButton�� �ʴ���� ���ϱ�
        }

        return totalGoldPerSec;
    }

}

