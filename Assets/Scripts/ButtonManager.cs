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

    public void Reborn() // 환생 버튼
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

    public void OnClick() // 돈 버는 버튼
    {
        int goldPerClick = DataController.GetInstance().GetGoldPerClick();
        DataController.GetInstance().AddGold(goldPerClick);
    }

    public void delete()
    {
        PlayerPrefs.DeleteAll(); // 저장된 데이터 모두 삭제
    }

    public void ReinforcementOpen() // 강화 패널 열기
    {
        ReinforcementPanel.SetActive(true);
    }

    public void ReinforcementClose() // 강화 패널 닫기
    {
        ReinforcementPanel.SetActive(false);
    }
}
