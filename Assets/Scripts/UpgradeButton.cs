using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public Text upgradeDisplayer; // ��� text
    public CostManager costManager; // csv ���� �ҷ��� ��
    public string upgradeName; // �ǹ� �̸�

    public int goldByUpgrade;
    public int startGoldByUpgrade = 1;

    public int currentCost = 1;
    public int startCurrentCost = 1;

    public int currentCost2; // �ǹ� ����

    public int level = 1;

    public float upgradePow = 1.07f;

    public float costPow = 3.14f;
    public int buildLevels; // �ǹ� ����
    public int buildNum; // �ǹ� ��ȣ

    void Start()
    {
        DataController.GetInstance().LoadUpgradeButton(this); // ��� ������ �ҷ���
        currentCost2 = costManager.buildingList.building[buildNum].levels[buildLevels]; // �ǹ� �ʱⰪ ����
        UpdateUI(); // UI ������Ʈ
    }

    public void PurchaseUpgrade() // �ǹ� ���׷��̵�
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

    public void UpdateUpgrade() // ���� ������Ʈ
    {
        goldByUpgrade = startGoldByUpgrade * (int)Mathf.Pow(upgradePow, level);
        // currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level);
        currentCost2 = costManager.buildingList.building[buildNum].levels[buildLevels];
    }

    public void UpdateUI() // text ������Ʈ
    {
        upgradeDisplayer.text = upgradeName + "\nCost : " + currentCost2 + "\nLevel : " + buildLevels;
    }
}
