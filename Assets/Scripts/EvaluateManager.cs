using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvaluateManager : MonoBehaviour
{
    public DataController dataController;
    public ButtonManager buttonManager;
    public AchievementManager achievementManager;

    public Text classText;  // 학교 등급 텍스트
    public Text AchievementText; // 평가 내용 텍스트

    public int finalClass; // 학교 등급 평가 변수

    //평가 내용
    private int valueGold;
    private int valueFacility;
    private int valueAchievement;
    private int valueTitle;

    public int divideClass; // 등급 구별 변수

    void Start()
    {
        dataController = DataController.GetInstance();
        // 변수 초기화
        valueGold = 0;
        valueFacility = 0;
        valueAchievement = 0;
        valueTitle = 0;

        divideClass = 30; //변수 초기화
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
        // 시간 멈추기
        Time.timeScale = 0;

        // 연도 새로고침
        dataController.currentYear = dataController.year[dataController.nameNumber - 1];

        // 점수 계산
        // 총 소비한 골드
        valueGold = dataController.GetTotalGold() / 1000;

        // 업그레이드 레벨
        Debug.Log("" + buttonManager.upgradeButtons.Length);
        for (int i = 0; i < buttonManager.upgradeButtons.Length; i++)
        {
            valueFacility += buttonManager.upgradeButtons[i].buildLevels * 5;
        }

        // 달성한 업적의 수
        for (int i = 0; i < achievementManager.achievementList.achievementsInfo.Length; i++)
        {
            if (achievementManager.achievementList.achievementsInfo[i].isAchieve == true)
            {
                valueAchievement++;
            }
        }

        // 칭호의 수
        // valueTitle = 

        // 점수의 합
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

        AchievementText.text = "재산 (총 소비한 돈) : " + dataController.GetTotalGold() + "원\n" + valueGold + "points\n시설(업그레이드 횟수) : " + valueFacility / 5 + "회\n" + valueFacility + "points\n업적 달성 횟수 : " + valueAchievement + "회\n" + valueAchievement + "points\n보유 칭호 수 : " + valueTitle / 10 + "개\n" + valueTitle + "points\n\n총합 : " + totalValue + "points";

        // 점수에 따라 평가하는 코드
        switch (finalClass)
        {
            case 1: classText.text = "현재 학교의 등급은 S입니다."; break;
            case 2: classText.text = "현재 학교의 등급은 A+입니다."; break;
            case 3: classText.text = "현재 학교의 등급은 A입니다."; break;
            case 4: classText.text = "현재 학교의 등급은 B+입니다."; break;
            case 5: classText.text = "현재 학교의 등급은 B입니다."; break;
            case 6: classText.text = "현재 학교의 등급은 C+입니다."; break;
            case 7: classText.text = "현재 학교의 등급은 C입니다."; break;
            case 8: classText.text = "현재 학교의 등급은 D+입니다."; break;
            case 9: classText.text = "현재 학교의 등급은 D입니다."; break;
            case 10: classText.text = "현재 학교의 등급은 F입니다."; break;

        }
    }

    public void onClose()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1; // 시간 다시 진행
    }
}
