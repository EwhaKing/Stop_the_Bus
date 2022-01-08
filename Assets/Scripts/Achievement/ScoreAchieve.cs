using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class ScoreAchieve : MonoBehaviour
{
    static int scoreNum;

    public static void UpdateStats()
    {
        SteamUserStats.RequestCurrentStats();

        SteamUserStats.GetStat("NEW_RECORD_COUNT", out scoreNum);
        scoreNum += 1;
        SteamUserStats.SetStat("NEW_RECORD_COUNT", scoreNum);

        if (scoreNum > 20)
        {
            return;
        }
        else if (scoreNum == 1) 
        {
            SteamUserStats.SetAchievement("FASTER_1ST"); 
        }
        else if (scoreNum == 3) 
        {
            SteamUserStats.SetAchievement("FASTER_3RD");
        }
        else if (scoreNum == 5) 
        {
            SteamUserStats.SetAchievement("FASTER_5TH");
        }
        else if (scoreNum == 10) 
        {
            SteamUserStats.SetAchievement("FASTER_10TH");
        }
        else if (scoreNum == 20) 
        {
            SteamUserStats.SetAchievement("FASTER_20TH");
        }

        SteamUserStats.StoreStats();
    }
}
