using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject ReinforcementPanel;
    public GameObject namePanel;
    private UpgradeButton[] upgradeButtons;
    UpgradeButton upgradeButton;
    CostManager costManager;

    void Start()
    {
        upgradeButtons = FindObjectsOfType<UpgradeButton>();
        upgradeButton = GetComponent<UpgradeButton>();
        costManager = GetComponent<CostManager>();
    }

    public void Reborn() // ȯ�� ��ư
    {
        ReinforcementPanel.SetActive(true);
        Debug.Log(upgradeButtons.Length);

        for (int i = 0; i < upgradeButtons.Length; i++)
        {
            upgradeButtons[i].buildLevels = 0;
            upgradeButtons[i].UpdateUpgrade();
            upgradeButtons[i].UpdateUI();

        }
        DataController.GetInstance().AddPayGoods(5);
        DataController.GetInstance().SetGoldPerClick(8);
        namePanel.SetActive(true);
    }

    public void OnClick() // �� ���� ��ư
    {
        int goldPerClick = DataController.GetInstance().GetGoldPerClick();
        DataController.GetInstance().AddGold(goldPerClick);
    }

    public void delete()
    {
        PlayerPrefs.DeleteAll(); // ����� ������ ��� ����
    }

    public void ReinforcementOpen() // ��ȭ �г� ����
    {
        ReinforcementPanel.SetActive(true);
    }

    public void ReinforcementClose() // ��ȭ �г� �ݱ�
    {
        ReinforcementPanel.SetActive(false);
    }
}
