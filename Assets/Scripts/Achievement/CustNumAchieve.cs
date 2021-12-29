using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class CustNumAchieve : MonoBehaviour
{
    
    static int custNum;
    
    public static void UpdateStats()
    {
        SteamUserStats.RequestCurrentStats();
        
        SteamUserStats.GetStat("PASSENGER_COUNT", out custNum);
        custNum += 1;
        SteamUserStats.SetStat("PASSENGER_COUNT", custNum);

        if (custNum > 200) return;
        else if (custNum == 1) { SteamUserStats.SetAchievement("FIRST_PASSENGER"); }
        else if (custNum == 100) { SteamUserStats.SetAchievement("100TH_PASSENGER"); }
        else if (custNum == 200) { SteamUserStats.SetAchievement("200TH_PASSENGER"); }

        SteamUserStats.StoreStats();
    }
}
