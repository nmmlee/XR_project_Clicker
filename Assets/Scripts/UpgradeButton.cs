using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public Text upgradeDisplayer; // 모든 text
    public Text costDisplayer;
    public Text buildingNameDisplayer;
    public CostManager costManager; // csv 정보 불러온 것
    public string buildingName; // 건물 이름

    public int goldByUpgrade; // 클릭 당 무료 재화 증가폭
    public int startGoldByUpgrade = 1; // 초기 무료 재화 증가폭

    public int buildingCost; // 건물 가격

    public int level = 1;

    public int buildLevels; // 건물 레벨
    public int buildNum; // 건물 번호

    public void Start()
    {
        DataController.GetInstance().LoadUpgradeButton(this); // 모든 데이터 불러옴
        buildingCost = costManager.buildingList.building[buildNum].levels[buildLevels]; // 건물 초기값 적용
        UpdateUI(); // UI 업데이트
    }

    public void PurchaseUpgrade() // 건물 업그레이드
    {
        if(DataController.GetInstance().GetGold() >= buildingCost)
        {
            DataController.GetInstance().SubGold(buildingCost);
            buildLevels++;
            DataController.GetInstance().AddGoldPerClick(goldByUpgrade);

            UpdateUpgrade();
            UpdateUI();
            DataController.GetInstance().SaveUpgradeButton(this); // 바뀐 변수들 저장
        }
        
    }

    public void UpdateUpgrade() // 가격 업데이트
    {
        goldByUpgrade += startGoldByUpgrade; // 클릭 당 무료 재화 증가
        buildingCost = costManager.buildingList.building[buildNum].levels[buildLevels];
    }

    public void UpdateUI() // text 업데이트
    {
        MaxLevelCheck();
        buildingNameDisplayer.text = buildingName;
        costDisplayer.text = buildingCost.ToString();
        upgradeDisplayer.text = "건물 Lv." + buildLevels.ToString();
    }

    public void MaxLevelCheck()
    {
        if (buildLevels >= 29)
        {
            this.GetComponent<Button>().interactable = false;
        }
        else
            this.GetComponent<Button>().interactable = true;
    }
}
