using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text goldDisplayer; // �� ���� ��ȭ text
    public Text goldPerClickDisplayer; // Ŭ�� �� ���� ��ȭ text
    public Text goldPerSecDisPlayer; // �ʴ� ���� ��ȭ text
    public Text payGoodsDisPlayer; // ���� ��ȭ text

    void Update()
    {
        goldDisplayer.text = DataController.GetInstance().GetGold().ToString();
        goldPerClickDisplayer.text = "GOLD PER CLICK : " + DataController.GetInstance().GetGoldPerClick();
        goldPerSecDisPlayer.text = "GOLD PER SEC : " + DataController.GetInstance().GetGoldPerSec();
        payGoodsDisPlayer.text = DataController.GetInstance().GetPayGoods().ToString();
    }
}
