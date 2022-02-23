using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvaluateManager : MonoBehaviour
{
    public DataController dataController;
    public ButtonManager buttonManager;
    public AchievementManager achievementManager;

    public Text classText;  // �б� ��� �ؽ�Ʈ
    public Text AchievementText; // �� ���� �ؽ�Ʈ

    public int finalClass; // �б� ��� �� ����

    //�� ����
    private int valueGold;
    private int valueFacility;
    private int valueAchievement;
    private int valueTitle;

    public int divideClass; // ��� ���� ����

    void Start()
    {
        dataController = DataController.GetInstance();
        // ���� �ʱ�ȭ
        valueGold = 0;
        valueFacility = 0;
        valueAchievement = 0;
        valueTitle = 0;

        divideClass = 30; //���� �ʱ�ȭ
    }

    void OnEnable()
    {
        Evaluation();

    }

    void Update()
    {

    }

    public void Evaluation()
    {
        // �ð� ���߱�
        Time.timeScale = 0;

        // ���� ���ΰ�ħ
        dataController.currentYear = dataController.year[dataController.nameNumber - 1];

        // ���� ���
        // �� �Һ��� ���
        valueGold = dataController.GetTotalGold() / 1000;

        // ���׷��̵� ����
        Debug.Log("" + buttonManager.upgradeButtons.Length);
        for (int i = 0; i < buttonManager.upgradeButtons.Length; i++)
        {
            valueFacility += buttonManager.upgradeButtons[i].buildLevels * 5;
        }

        // �޼��� ������ ��
        for (int i = 0; i < achievementManager.achievementList.achievementsInfo.Length; i++)
        {
            if (achievementManager.achievementList.achievementsInfo[i].isAchieve == true)
            {
                valueAchievement++;
            }
        }

        // Īȣ�� ��
        // valueTitle = 

        // ������ ��
        int totalValue = valueGold + valueFacility + valueAchievement + valueTitle;

        if (totalValue > 10 * divideClass)
        {
            finalClass = 1;
        }
        else if (totalValue > 9 * divideClass)
        {
            finalClass = 2;
        }
        else if (totalValue > 8 * divideClass)
        {
            finalClass = 3;
        }
        else if (totalValue > 7 * divideClass)
        {
            finalClass = 4;
        }
        else if (totalValue > 6 * divideClass)
        {
            finalClass = 5;
        }
        else if (totalValue > 5 * divideClass)
        {
            finalClass = 6;
        }
        else if (totalValue > 4 * divideClass)
        {
            finalClass = 7;
        }
        else if (totalValue > 3 * divideClass)
        {
            finalClass = 8;
        }
        else if (totalValue > 2 * divideClass)
        {
            finalClass = 9;
        }
        else if (totalValue > 0)
        {
            finalClass = 10;
        }

        AchievementText.text = "��� (�� �Һ��� ��) : " + dataController.GetTotalGold() + "��\n" + valueGold + "points\n�ü�(���׷��̵� Ƚ��) : " + valueFacility / 5 + "ȸ\n" + valueFacility + "points\n���� �޼� Ƚ�� : " + valueAchievement + "ȸ\n" + valueAchievement + "points\n���� Īȣ �� : " + valueTitle / 10 + "��\n" + valueTitle + "points\n\n���� : " + totalValue + "points";

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

    public void onClose()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1; // �ð� �ٽ� ����
    }
}
