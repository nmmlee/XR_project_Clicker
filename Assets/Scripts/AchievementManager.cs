using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    [System.Serializable]
    public class AchievementInfo // ���� ����
    {
        public string achievementName; // ���� �̸�
        public string explanation;
        public bool isAchieve; // �޼��Ǿ��°�
    }

    [System.Serializable]
    public class AchievementList
    {
        public AchievementInfo[] achievementsInfo; // �����鿡 ���� Ŭ����
    }

    public AchievementList achievementList = new AchievementList();

    public Text[] achievementNameText;
    public Text[] achievementExplanationText;

    void Awake()
    {
        List<Dictionary<string, object>> data_test = CSVReader.Read("GameString");
        achievementList.achievementsInfo = new AchievementInfo[data_test.Count];
        for (var i = 0; i < data_test.Count; i++)
        {
            achievementList.achievementsInfo[i] = new AchievementInfo();
            achievementList.achievementsInfo[i].achievementName = (string)data_test[i]["name"];
            achievementList.achievementsInfo[i].explanation = (string)data_test[i]["string"];
        }
    }

    void Start()
    {
        for (var i = 0; i < achievementList.achievementsInfo.Length; i++)
        {
            achievementNameText[i].text = achievementList.achievementsInfo[i].achievementName;
            achievementExplanationText[i].text = achievementList.achievementsInfo[i].explanation;
        }

        
    }

    private void Update()
    {
        DataController.GetInstance().LoadAchievement(this);
    }
}
