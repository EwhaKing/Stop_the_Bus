using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class CustNumAchieve : MonoBehaviour
{
    int countPassenger;
    static int temp;
    
    void Update()
    {
        if (!SteamManager.Initialized) { return; }

        SteamUserStats.RequestCurrentStats();

        SteamUserStats.GetStat("PASSENGER_COUNT", out countPassenger);
        Debug.Log(countPassenger);

        //SteamUserStats.ResetAllStats(true);

        if (countPassenger == 1) { SteamUserStats.SetAchievement("FIRST_PASSENGER"); }
        if (countPassenger == 100) { SteamUserStats.SetAchievement("100TH_PASSENGER"); }
        if (countPassenger == 200) { SteamUserStats.SetAchievement("200TH_PASSENGER"); }
             
        SteamUserStats.StoreStats();

    }

    public static void UpdateStats()
    {
        SteamUserStats.RequestCurrentStats();
        
        SteamUserStats.GetStat("PASSENGER_COUNT", out temp);
        SteamUserStats.SetStat("PASSENGER_COUNT", ++temp);
        Debug.Log(temp);

        SteamUserStats.StoreStats();
    }
}
