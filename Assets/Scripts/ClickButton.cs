using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    public GameObject ReinforcementPanel;
    private UpgradeButton[] upgradeButtons;

    void Start()
    {
        upgradeButtons = FindObjectsOfType<UpgradeButton>();
    }

    public void Reborn() // ȯ�� ��ư
    {
        ReinforcementPanel.SetActive(true);
        Debug.Log(upgradeButtons.Length);

        for (int i = 0; i < upgradeButtons.Length; i++)
        {
            upgradeButtons[i].buildLevels = 0;
        }

        DataController.GetInstance().AddPayGoods(5);
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
