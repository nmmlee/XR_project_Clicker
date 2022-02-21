using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject ReinforcementPanel;
    public GameObject namePanel;
    public GameObject AcheivementPanel;

    private UpgradeButton[] upgradeButtons;

    UpgradeButton upgradeButton;
    CostManager costManager;

    void Start()
    {
        upgradeButtons = FindObjectsOfType<UpgradeButton>();
        upgradeButton = GetComponent<UpgradeButton>();
        costManager = GetComponent<CostManager>();
    }

    public void Reborn() // 환생 버튼
    {
        ReinforcementPanel.SetActive(true);
        Debug.Log(upgradeButtons.Length);

        for (int i = 0; i < upgradeButtons.Length; i++)
        {
            upgradeButtons[i].buildLevels = 0; // 강화 레벨 0

            // 버튼 텍스트 업데이트
            upgradeButtons[i].UpdateUpgrade();
            upgradeButtons[i].UpdateUI();

        }
        DataController.GetInstance().AddPayGoods(5); // 유료 재화 추가
        DataController.GetInstance().SetGoldPerClick(8); // 클릭 당 무료 재화 건물 8개-> 8
        namePanel.SetActive(true);
    }

    // 저장된 데이터 모두 삭제
    public void delete()
    {
        PlayerPrefs.DeleteAll();
    }

    // 강화 패널 열기
    public void ReinforcementOpen()
    {
        ReinforcementPanel.SetActive(true);
    }

    // 강화 패널 닫기
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
