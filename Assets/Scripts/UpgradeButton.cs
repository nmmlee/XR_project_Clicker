using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public Text upgradeDisplayer;
    public CostManager costManager;

    public string upgradeName;

    //[HideInInspector]
    public int goldByUpgrade;
    public int startGoldByUpgrade = 1;

    //[HideInInspector]
    public int currentCost = 1;
    public int startCurrentCost = 1;

    public int currentCost2;
   

    //[HideInInspector]
    public int level = 1;

    public float upgradePow = 1.07f;

    public float costPow = 3.14f;
    public int buildLevels;

    void Start()
    {
        DataController.GetInstance().LoadUpgradeButton(this);
        currentCost2 = costManager.buildingList.building[0].levels[buildLevels];
        UpdateUI();
    }

    public void PurchaseUpgrade()
    {
        if(DataController.GetInstance().GetGold() >= currentCost2)
        {
            DataController.GetInstance().SubGold(currentCost2);
            buildLevels++;
            DataController.GetInstance().AddGoldPerClick(goldByUpgrade);

            UpdateUpgrade();
            UpdateUI();
            DataController.GetInstance().SaveUpgradeButton(this);
        }
        
    }

    public void UpdateUpgrade()
    {
        goldByUpgrade = startGoldByUpgrade * (int)Mathf.Pow(upgradePow, level);
        // currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level);
        currentCost2 = costManager.buildingList.building[0].levels[buildLevels];
    }

    public void UpdateUI()
    {
        upgradeDisplayer.text = upgradeName + "\nCost : " + currentCost2 + "\nLevel : " + buildLevels;
    }
}
