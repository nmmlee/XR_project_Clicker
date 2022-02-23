using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public Text upgradeDisplayer; // ��� text
    public Text costDisplayer;
    public Text buildingNameDisplayer;
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
        MaxLevelCheck();
        buildingNameDisplayer.text = buildingName;
        costDisplayer.text = buildingCost.ToString();
        upgradeDisplayer.text = "�ǹ� Lv." + buildLevels.ToString();
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
