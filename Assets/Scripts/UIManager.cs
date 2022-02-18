using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text goldDisplayer; // 총 무료 재화 text
    public Text goldPerClickDisplayer; // 클릭 당 무료 재화 text
    public Text goldPerSecDisPlayer; // 초당 무료 재화 text
    public Text payGoodsDisPlayer; // 유료 재화 text

    void Update()
    {
        goldDisplayer.text = DataController.GetInstance().GetGold().ToString();
        goldPerClickDisplayer.text = "GOLD PER CLICK : " + DataController.GetInstance().GetGoldPerClick();
        goldPerSecDisPlayer.text = "GOLD PER SEC : " + DataController.GetInstance().GetGoldPerSec();
        payGoodsDisPlayer.text = DataController.GetInstance().GetPayGoods().ToString();
    }
}
