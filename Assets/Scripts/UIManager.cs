using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text goldDisplayer; // �� ���� ��ȭ text
    public Text totalGoldDisplayer; // �� ���� ��ȭ text
    public Text goldPerClickDisplayer; // Ŭ�� �� ���� ��ȭ text
    public Text goldPerSecDisPlayer; // �ʴ� ���� ��ȭ text
    public Text payGoodsDisPlayer; // ���� ��ȭ text

    public Text semesterText; // �б� �ؽ�Ʈ

    public string playerName; // �÷��̾� �̸�
    public int playerNum; // �� �� ��������

    public int[] year; //�� �� ������ �� �� ���� �ߴ���
    public int[] semester; // �� �� ������ �� �б� ���� �ߴ���

    public DataController dataController;

    private void Start()
    {
        dataController = DataController.GetInstance(); // ��������Ʈ�ѷ� �ν��Ͻ� ��������

    }

    private void Update()
    {
        goldDisplayer.text = DataController.GetInstance().GetGold().ToString();
        totalGoldDisplayer.text = DataController.GetInstance().GetTotalGold().ToString();
        goldPerClickDisplayer.text = "GOLD PER CLICK : " + DataController.GetInstance().GetGoldPerClick();
        goldPerSecDisPlayer.text = "GOLD PER SEC : " + DataController.GetInstance().GetGoldPerSec();
        payGoodsDisPlayer.text = DataController.GetInstance().GetPayGoods().ToString();

        UpdateText();
    }

    // �б� �ؽ�Ʈ ������Ʈ
    private void UpdateText()
    {
        if (dataController.nameNumber <= 0)
        {
            return;
        }

        playerNum = dataController.nameNumber - 1; // �� �� ��������
        playerName = dataController.Names[playerNum]; // �÷��̾� �̸�

        year = new int[dataController.nameNumber]; //�� �� ������ �� �� ���� �ߴ���
        semester = new int[dataController.nameNumber]; // �� �� ������ �� �б� ���� �ߴ���

        year[playerNum] = (int)dataController.playTime / 60;

        if (dataController.playTime % 60 > 45)
        {
            semester[playerNum] = 4;
        }
        else if (dataController.playTime % 60 > 30)
        {
            semester[playerNum] = 3;
        }
        else if (dataController.playTime % 60 > 15)
        {
            semester[playerNum] = 2;
        }
        else if (dataController.playTime % 60 > 0)
        {
            semester[playerNum] = 1;
        }

        switch (semester[playerNum])
        {
            case 1: semesterText.text = "" + year[playerNum] + "�� " + "��"; break;
            case 2: semesterText.text = "" + year[playerNum] + "�� " + "����"; break;
            case 3: semesterText.text = "" + year[playerNum] + "�� " + "����"; break;
            case 4: semesterText.text = "" + year[playerNum] + "�� " + "�ܿ�"; break;
        }

        return;
    }
}
