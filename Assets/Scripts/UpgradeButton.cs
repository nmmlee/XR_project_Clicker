using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public Text upgradeDisplayer; // 모든 text
    public CostManager costManager; // csv 정보 불러온 것
    public string upgradeName; // 건물 이름

    public int goldByUpgrade;
    public int startGoldByUpgrade = 1;

    public int currentCost = 1;
    public int startCurrentCost = 1;

    public int currentCost2; // 건물 가격

    public int level = 1;

    public float upgradePow = 1.07f;

    public float costPow = 3.14f;
    public int buildLevels; // 건물 레벨
    public int buildNum; // 건물 번호

    void Start()
    {
        DataController.GetInstance().LoadUpgradeButton(this); // 모든 데이터 불러옴
        currentCost2 = costManager.buildingList.building[buildNum].levels[buildLevels]; // 건물 초기값 적용
        UpdateUI(); // UI 업데이트
    }

    public void PurchaseUpgrade() // 건물 업그레이드
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

    public void UpdateUpgrade() // 가격 업데이트
    {
        goldByUpgrade = startGoldByUpgrade * (int)Mathf.Pow(upgradePow, level);
        // currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level);
        currentCost2 = costManager.buildingList.building[buildNum].levels[buildLevels];
    }

    public void UpdateUI() // text 업데이트
    {
        upgradeDisplayer.text = upgradeName + "\nCost : " + currentCost2 + "\nLevel : " + buildLevels;
    }
}
