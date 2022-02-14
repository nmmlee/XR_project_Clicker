using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{ 
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


    private int m_gold = 100000;

    private int m_goldPerClick = 0;

    void Awake()
    {
        m_gold = PlayerPrefs.GetInt("Gold");
        m_goldPerClick = PlayerPrefs.GetInt("GoldPerClick", 1);

        itemButtons = FindObjectsOfType<ItemButton>();
    }

    public void SetGold(int newGold)
    {
        m_gold = newGold;
        PlayerPrefs.SetInt("Gold", m_gold);
    }

    public void AddGold(int newGold)
    {
        m_gold += newGold;
        SetGold(m_gold);
    }

    public void SubGold(int newGold)
    {
        m_gold -= newGold;
        SetGold(m_gold);
    }

    public int GetGold()
    {
        return m_gold;
    }

    public int GetGoldPerClick()
    {
        return m_goldPerClick;
    }

    public void SetGoldPerClick(int newGoldPerClick)
    {
        m_goldPerClick = newGoldPerClick;
        PlayerPrefs.SetInt("GoldPerClick", m_goldPerClick);
    }
    public void AddGoldPerClick(int newGoldPerClick)
    {
        m_goldPerClick += newGoldPerClick;
        SetGoldPerClick(m_goldPerClick);
    }

    public void LoadUpgradeButton(UpgradeButton upgradeButton)
    {
        string key = upgradeButton.upgradeName;

        upgradeButton.level = PlayerPrefs.GetInt(key + "_level", 1);
        upgradeButton.goldByUpgrade = PlayerPrefs.GetInt(key + "_goldByUpgrade", upgradeButton.startGoldByUpgrade);
        upgradeButton.currentCost = PlayerPrefs.GetInt(key + "_cost", upgradeButton.startCurrentCost);
        upgradeButton.buildLevels = PlayerPrefs.GetInt(key + "_level", 0);
    }

    public void SaveUpgradeButton(UpgradeButton upgradeButton)
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

    public int GetGoldPerSec()
    {
        int totalGoldPerSec = 0;

        for(int i = 0; i < itemButtons.Length; i++)
        {
            totalGoldPerSec += itemButtons[i].goldPerSec;
        }

        return totalGoldPerSec;
    }
}
