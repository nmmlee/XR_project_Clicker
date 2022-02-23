using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject ReinforcementPanel;
    public GameObject namePanel;
    public GameObject AcheivementPanel;

    public UpgradeButton[] upgradeButtons;

    // ȯ�� ����( ��� ��ư 10�� �޼�)
    public int rebornPossible = 0;
    public bool is10Level = false;

    UpgradeButton upgradeButton;
    CostManager costManager;

    Vector3 pos;
    Vector3 pos2;

    void Start()
    {
        upgradeButtons = FindObjectsOfType<UpgradeButton>();
        upgradeButton = GetComponent<UpgradeButton>();
        costManager = GetComponent<CostManager>();

        pos = ReinforcementPanel.transform.position;
        pos.y = -1058;

        pos2 = ReinforcementPanel.transform.position;
        pos2.y = -18;
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
                DataController.GetInstance().SaveUpgradeButton(upgradeButtons[i]);

            }
            DataController.GetInstance().AddPayGoods(5); // ���� ��ȭ �߰�
            DataController.GetInstance().SetGoldPerClick(8); // Ŭ�� �� ���� ��ȭ �ǹ� 8��-> 8
            namePanel.SetActive(true);

            
        }

        else
            Debug.Log("10�� �� ��");

        rebornPossible = 0;
    }

    // ����� ������ ��� ����
    public void delete()
    {
        PlayerPrefs.DeleteAll();
    }

    // ��ȭ �г� ����
    public void ReinforcementOpen()
    {
        ReinforcementPanel.transform.position = pos2;
        // ReinforcementPanel.SetActive(true);
    }

    // ��ȭ �г� �ݱ�
    public void ReinforcementClose()
    {
        ReinforcementPanel.transform.position = pos;
        // ReinforcementPanel.SetActive(false);
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
