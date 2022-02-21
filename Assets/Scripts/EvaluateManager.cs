using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvaluateManager : MonoBehaviour
{
    DataController dataController;

    public Text classText;  // �б� ��� �ؽ�Ʈ
    public Text AchievementText; // �� ���� �ؽ�Ʈ

    public int finalClass; // �б� ��� �� ����

    private int valueGold;
    private int valueFacility;
    private int valueAchievement;
    private int valueTitle;


    int currentYear;

    void Start()
    {
        dataController = DataController.GetInstance();

    }

    void Update()
    {

    }

    public void Evaluation()
    {

        currentYear = dataController.year[dataController.nameNumber];

        // ������ �ٲ���� Ȯ���ϴ� �ڵ�
        if (dataController.year[dataController.nameNumber] == currentYear)
        {
            return;
        }

        // ���� ���
        finalClass = valueGold + valueFacility + valueAchievement + valueTitle;

        // ������ ���� ���ϴ� �ڵ�
        switch (finalClass)
        {
            case 1: classText.text = "���� �б��� ����� S�Դϴ�."; break;
            case 2: classText.text = "���� �б��� ����� A+�Դϴ�."; break;
            case 3: classText.text = "���� �б��� ����� A�Դϴ�."; break;
            case 4: classText.text = "���� �б��� ����� B+�Դϴ�."; break;
            case 5: classText.text = "���� �б��� ����� B�Դϴ�."; break;
            case 6: classText.text = "���� �б��� ����� C+�Դϴ�."; break;
            case 7: classText.text = "���� �б��� ����� C�Դϴ�."; break;
            case 8: classText.text = "���� �б��� ����� D+�Դϴ�."; break;
            case 9: classText.text = "���� �б��� ����� D�Դϴ�."; break;
            case 10: classText.text = "���� �б��� ����� F�Դϴ�."; break;

        }

    }
}
