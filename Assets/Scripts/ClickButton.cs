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

    public void Reborn() // 환생 버튼
    {
        ReinforcementPanel.SetActive(true);
        Debug.Log(upgradeButtons.Length);

        for (int i = 0; i < upgradeButtons.Length; i++)
        {
            upgradeButtons[i].buildLevels = 0;
        }

        DataController.GetInstance().AddPayGoods(5);
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
