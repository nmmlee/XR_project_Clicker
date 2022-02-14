using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text goldDisplayer;
    public Text goldPerClickDisplayer;
    public Text goldPerSecDisPlayer;

    void Update()
    {
        goldDisplayer.text = "Gold : " + DataController.GetInstance().GetGold();
        goldPerClickDisplayer.text = "GOLD PER CLICK : " + DataController.GetInstance().GetGoldPerClick();
        goldPerSecDisPlayer.text = "GOLD PER SEC : " + DataController.GetInstance().GetGoldPerSec();
    }
}
