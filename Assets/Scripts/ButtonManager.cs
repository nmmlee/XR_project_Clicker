using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject ReinforcementPanel;
    public GameObject namePanel;
    public GameObject AcheivementPanel;

    public UpgradeButton[] upgradeButtons;

    // 환생 조건( 모든 버튼 10렙 달성)
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

    public void Reborn() // 환생 버튼
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
                upgradeButtons[i].buildLevels = 0; // 강화 레벨 0

                // 버튼 텍스트 업데이트
                upgradeButtons[i].UpdateUpgrade();
                upgradeButtons[i].UpdateUI();
                DataController.GetInstance().SaveUpgradeButton(upgradeButtons[i]);

            }
            DataController.GetInstance().AddPayGoods(5); // 유료 재화 추가
            DataController.GetInstance().SetGoldPerClick(8); // 클릭 당 무료 재화 건물 8개-> 8
            namePanel.SetActive(true);

            
        }

        else
            Debug.Log("10렙 안 됨");

        rebornPossible = 0;
    }

    // 저장된 데이터 모두 삭제
    public void delete()
    {
        PlayerPrefs.DeleteAll();
    }

    // 강화 패널 열기
    public void ReinforcementOpen()
    {
        ReinforcementPanel.transform.position = pos2;
        // ReinforcementPanel.SetActive(true);
    }

    // 강화 패널 닫기
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
