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

    public Text semesterText; // 학기 텍스트

    public string playerName; // 플레이어 이름
    public int playerNum; // 몇 대 총장인지

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

        UpdateText();
    }

    // 학기 텍스트 업데이트
    private void UpdateText()
    {
        if (dataController.nameNumber <= 0)
        {
            return;
        }

        playerNum = dataController.nameNumber - 1; // 몇 대 총장인지
        playerName = dataController.Names[playerNum]; // 플레이어 이름


        dataController.year[playerNum] = (int)dataController.playTime / 60;

        if (dataController.playTime % 60 > 45)
        {
            dataController.semester[playerNum] = 4;
        }
        else if (dataController.playTime % 60 > 30)
        {
            dataController.semester[playerNum] = 3;
        }
        else if (dataController.playTime % 60 > 15)
        {
            dataController.semester[playerNum] = 2;
        }
        else if (dataController.playTime % 60 > 0)
        {
            dataController.semester[playerNum] = 1;
        }

        switch (dataController.semester[playerNum])
        {
            case 1: semesterText.text = "" + dataController.year[playerNum] + "년 " + "봄"; break;
            case 2: semesterText.text = "" + dataController.year[playerNum] + "년 " + "여름"; break;
            case 3: semesterText.text = "" + dataController.year[playerNum] + "년 " + "가을"; break;
            case 4: semesterText.text = "" + dataController.year[playerNum] + "년 " + "겨울"; break;
        }

    }
}
