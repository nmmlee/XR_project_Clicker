using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementChecker : MonoBehaviour
{
    public AchievementManager achievementManager;
    public DataController dataController;
    public ButtonManager buttonManager;

    private int Money_1 = 10000;
    private int Money_2 = 20000;
    private int Money_3 = 30000;
    private int Money_4 = 40000;
    private int Money_5 = 50000;

    private int Unlock_1 = 1;
    private int Unlock_2 = 2;
    private int Unlock_3 = 3;
    private int Unlock_4 = 4;
    private int Unlock_5 = 5;
    private int Unlock_6 = 6;
    private int Unlock_7 = 7;
    private int Unlock_8 = 8;

    private int unlockButtonCount;

    private int MaxLevel_1 = 1;
    private int MaxLevel_2 = 2;
    private int MaxLevel_3 = 3;
    private int MaxLevel_4 = 4;
    private int MaxLevel_5 = 5;
    private int MaxLevel_6 = 6;
    private int MaxLevel_7 = 7;
    private int MaxLevel_8 = 8;

    private int maxLevelButtonCount;

    void Update()
    {
        AchievementMoney();
        AchievementUnlock();
        AchievementMaxLevel();
    }

    public void AchievementMoney()
    {
        if (DataController.GetInstance().GetTotalGold() >= Money_1)
        {
            achievementManager.achievementList.achievementsInfo[0].isAchieve = true;
        }

        if (DataController.GetInstance().GetTotalGold() >= Money_2)
        {
            achievementManager.achievementList.achievementsInfo[1].isAchieve = true;
        }

        if (DataController.GetInstance().GetTotalGold() >= Money_3)
        {
            achievementManager.achievementList.achievementsInfo[2].isAchieve = true;
        }

        if (DataController.GetInstance().GetTotalGold() >= Money_4)
        {
            achievementManager.achievementList.achievementsInfo[3].isAchieve = true;
        }

        if (DataController.GetInstance().GetTotalGold() >= Money_5)
        {
            achievementManager.achievementList.achievementsInfo[4].isAchieve = true;
        }

    }

    public void AchievementUnlock()
    {
        for (int i = 0; i < dataController.itemButtons.Length; i++)
        {
            if (dataController.itemButtons[i].isPurchase == true)
            {
                unlockButtonCount++;
            }
        }

        if (unlockButtonCount == Unlock_1)
        {
            achievementManager.achievementList.achievementsInfo[5].isAchieve = true;
        }

        if (unlockButtonCount == Unlock_2)
        {
            achievementManager.achievementList.achievementsInfo[6].isAchieve = true;
        }

        if (unlockButtonCount == Unlock_3)
        {
            achievementManager.achievementList.achievementsInfo[7].isAchieve = true;
        }

        if (unlockButtonCount == Unlock_4)
        {
            achievementManager.achievementList.achievementsInfo[8].isAchieve = true;
        }

        if (unlockButtonCount == Unlock_5)
        {
            achievementManager.achievementList.achievementsInfo[9].isAchieve = true;
        }

        if (unlockButtonCount == Unlock_6)
        {
            achievementManager.achievementList.achievementsInfo[10].isAchieve = true;
        }

        if (unlockButtonCount == Unlock_7)
        {
            achievementManager.achievementList.achievementsInfo[11].isAchieve = true;
        }

        if (unlockButtonCount == Unlock_8)
        {
            achievementManager.achievementList.achievementsInfo[12].isAchieve = true;
        }

        unlockButtonCount = 0;

    }

    public void AchievementMaxLevel()
    {
        for (int i = 0; i < buttonManager.upgradeButtons.Length; i++)
        {
            if (buttonManager.upgradeButtons[i].buildLevels >= 28)
            {
                maxLevelButtonCount++;
            }
        }

        if (maxLevelButtonCount == MaxLevel_1)
        {
            achievementManager.achievementList.achievementsInfo[13].isAchieve = true;
        }

        if (maxLevelButtonCount == MaxLevel_2)
        {
            achievementManager.achievementList.achievementsInfo[14].isAchieve = true;
        }

        if (maxLevelButtonCount == MaxLevel_3)
        {
            achievementManager.achievementList.achievementsInfo[15].isAchieve = true;
        }

        if (maxLevelButtonCount == MaxLevel_4)
        {
            achievementManager.achievementList.achievementsInfo[16].isAchieve = true;
        }

        if (maxLevelButtonCount == MaxLevel_5)
        {
            achievementManager.achievementList.achievementsInfo[17].isAchieve = true;
        }

        if (maxLevelButtonCount == MaxLevel_6)
        {
            achievementManager.achievementList.achievementsInfo[18].isAchieve = true;
        }

        if (maxLevelButtonCount == MaxLevel_7)
        {
            achievementManager.achievementList.achievementsInfo[19].isAchieve = true;
        }

        if (maxLevelButtonCount == MaxLevel_8)
        {
            achievementManager.achievementList.achievementsInfo[20].isAchieve = true;
        }

        maxLevelButtonCount = 0;
    }
}
