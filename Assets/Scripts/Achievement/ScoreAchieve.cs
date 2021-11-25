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
        Debug.Log(countNewScore);

        //SteamUserStats.ResetAllStats(true);
        
        if (countNewScore == 1) 
        {
            SteamUserStats.SetAchievement("FASTER_1ST"); 
        }
        
        if (countNewScore == 3) 
        {
            SteamUserStats.SetAchievement("FASTER_3RD");
        }
        
        if (countNewScore == 5) 
        {
            SteamUserStats.SetAchievement("FASTER_5TH");
        }

        if (countNewScore == 10) 
        {
            SteamUserStats.SetAchievement("FASTER_10TH");
        }
        
        if (countNewScore == 20) 
        {
            SteamUserStats.SetAchievement("FASTER_20TH");
        }

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
