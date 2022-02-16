using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text goldDisplayer; // �� ��� text
    public Text goldPerClickDisplayer; // Ŭ�� �� ��� text
    public Text goldPerSecDisPlayer; // �ʴ� ��� text

    void Update()
    {
        goldDisplayer.text = "Gold : " + DataController.GetInstance().GetGold();
        goldPerClickDisplayer.text = "GOLD PER CLICK : " + DataController.GetInstance().GetGoldPerClick();
        goldPerSecDisPlayer.text = "GOLD PER SEC : " + DataController.GetInstance().GetGoldPerSec();
    }
}
