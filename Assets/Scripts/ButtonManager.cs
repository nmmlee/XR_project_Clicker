using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject ReinforcementPanel;
    public GameObject namePanel;
    public GameObject AcheivementPanel;

    private UpgradeButton[] upgradeButtons;

    // ȯ�� ����( ��� ��ư 10�� �޼�)
    public int rebornPossible = 0;
    public bool is10Level = false;

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
        for (int i = 0; i < upgradeButtons.Length; i++)
        {
            if (upgradeButtons[i].buildLevels >= 10)
            {
                rebornPossible += 1;
            }

        }

        Debug.Log(rebornPossible);

        if (rebornPossible == 8)
        {
            is10Level = true;
        }
        else
        {
            is10Level = false;
        }

        if (is10Level)
        {
            ReinforcementPanel.SetActive(true);
            Debug.Log(upgradeButtons.Length);

            for (int i = 0; i < upgradeButtons.Length; i++)
            {
                upgradeButtons[i].buildLevels = 0; // ��ȭ ���� 0

                // ��ư �ؽ�Ʈ ������Ʈ
                upgradeButtons[i].UpdateUpgrade();
                upgradeButtons[i].UpdateUI();

            }
            DataController.GetInstance().AddPayGoods(5); // ���� ��ȭ �߰�
            DataController.GetInstance().SetGoldPerClick(8); // Ŭ�� �� ���� ��ȭ �ǹ� 8��-> 8
            namePanel.SetActive(true);

            rebornPossible = 0;
        }

        else
            Debug.Log("10�� �� ��");
    }

    // ����� ������ ��� ����
    public void delete()
    {
        PlayerPrefs.DeleteAll();
    }

    // ��ȭ �г� ����
    public void ReinforcementOpen()
    {
        ReinforcementPanel.SetActive(true);
    }

    // ��ȭ �г� �ݱ�
    public void ReinforcementClose()
    {
        ReinforcementPanel.SetActive(false);
    }

    public void AcheivementOpen()
    {
        AcheivementPanel.SetActive(true);
    }

    public void AcheivementClose()
    {
        AcheivementPanel.SetActive(false);
    }
}
