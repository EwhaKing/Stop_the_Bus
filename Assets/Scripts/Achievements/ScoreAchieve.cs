using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class ScoreAchieve : MonoBehaviour
{
    int countNewScore;
    static int temp;

    // Update is called once per frame
    void Update()
    {
        if (!SteamManager.Initialized) { return; }

        SteamUserStats.RequestCurrentStats();

        SteamUserStats.GetStat("NEW_RECORD_COUNT", out countNewScore);

        //SteamUserStats.ResetAllStats(true);

        if(countNewScore == 1) { return; }
        SteamUserStats.SetAchievement("FASTER_1ST");

        if (countNewScore == 3) { return; }
        SteamUserStats.SetAchievement("FASTER_3RD");

        if (countNewScore == 5) { return; }
        SteamUserStats.SetAchievement("FASTER_5TH");

        if (countNewScore == 10) { return; }
        SteamUserStats.SetAchievement("FASTER_10TH");

        if (countNewScore == 20) { return; }
        SteamUserStats.SetAchievement("FASTER_20TH");

        SteamUserStats.StoreStats();
    }

    public static void UpdateStats()
    {
        SteamUserStats.RequestCurrentStats();

        SteamUserStats.GetStat("NEW_RECORD_COUNT", out temp);
        SteamUserStats.SetStat("NEW_RECORD_COUNT", ++temp);

        SteamUserStats.StoreStats();
    }
}
