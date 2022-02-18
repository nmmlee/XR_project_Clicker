using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public Text upgradeDisplayer; // ��� text
    public CostManager costManager; // csv ���� �ҷ��� ��
    public string buildingName; // �ǹ� �̸�

    public int goldByUpgrade; // Ŭ�� �� ���� ��ȭ ������
    public int startGoldByUpgrade = 1; // �ʱ� ���� ��ȭ ������

    public int buildingCost; // �ǹ� ����

    public int level = 1;

    public int buildLevels; // �ǹ� ����
    public int buildNum; // �ǹ� ��ȣ

    public void Start()
    {
        DataController.GetInstance().LoadUpgradeButton(this); // ��� ������ �ҷ���
        buildingCost = costManager.buildingList.building[buildNum].levels[buildLevels]; // �ǹ� �ʱⰪ ����
        UpdateUI(); // UI ������Ʈ
    }

    public void PurchaseUpgrade() // �ǹ� ���׷��̵�
    {
        if(DataController.GetInstance().GetGold() >= buildingCost)
        {
            DataController.GetInstance().SubGold(buildingCost);
            buildLevels++;
            DataController.GetInstance().AddGoldPerClick(goldByUpgrade);

            UpdateUpgrade();
            UpdateUI();
            DataController.GetInstance().SaveUpgradeButton(this); // �ٲ� ������ ����
        }
        
    }

    public void UpdateUpgrade() // ���� ������Ʈ
    {
        goldByUpgrade += startGoldByUpgrade; // Ŭ�� �� ���� ��ȭ ����
        buildingCost = costManager.buildingList.building[buildNum].levels[buildLevels];
    }

    public void UpdateUI() // text ������Ʈ
    {
        upgradeDisplayer.text = buildingName + "\nCost : " + buildingCost + "\nLevel : " + buildLevels;
    }
}
