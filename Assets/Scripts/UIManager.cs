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
        goldPerClickDisplayer.text = "GOLD PER CLICK : " + DataController.GetInstance().GetGoldPerClick();
        goldPerSecDisPlayer.text = "GOLD PER SEC : " + DataController.GetInstance().GetGoldPerSec();
        payGoodsDisPlayer.text = DataController.GetInstance().GetPayGoods().ToString();
    }

    private void UpdateText()
    {
        year = new int[playerNum]; //�� �� ������ �� �� ���� �ߴ���
        semester = new int[playerNum]; // �� �� ������ �� �б� ���� �ߴ���

        return;
    }
}
