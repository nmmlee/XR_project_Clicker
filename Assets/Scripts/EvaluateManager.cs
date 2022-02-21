using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvaluateManager : MonoBehaviour
{
    DataController dataController;

    public Text classText;  // 학교 등급 텍스트
    public Text AchievementText; // 평가 내용 텍스트

    public int finalClass; // 학교 등급 평가 변수

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

        // 연도가 바뀌는지 확인하는 코드
        if (dataController.year[dataController.nameNumber] == currentYear)
        {
            return;
        }

        // 점수 계산
        finalClass = valueGold + valueFacility + valueAchievement + valueTitle;

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
}
