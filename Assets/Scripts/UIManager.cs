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

    public string playerName; // 플레이어 이름
    public int playerNum; // 몇 대 총장인지

    public int[] year; //몇 대 총장이 몇 년 까지 했는지
    public int[] semester; // 몇 대 총장이 몇 학기 까지 했는지

    public DataController dataController;

    private void Start()
    {
        dataController = DataController.GetInstance(); // 데이터컨트롤러 인스턴스 가져오기

    }

    private void Update()
    {

        goldDisplayer.text = DataController.GetInstance().GetGold().ToString();
        goldPerClickDisplayer.text = "GOLD PER CLICK : " + DataController.GetInstance().GetGoldPerClick();
        goldPerSecDisPlayer.text = "GOLD PER SEC : " + DataController.GetInstance().GetGoldPerSec();
        payGoodsDisPlayer.text = DataController.GetInstance().GetPayGoods().ToString();
    }

    private void UpdateText()
    {
        year = new int[playerNum]; //몇 대 총장이 몇 년 까지 했는지
        semester = new int[playerNum]; // 몇 대 총장이 몇 학기 까지 했는지

        return;
    }
}
