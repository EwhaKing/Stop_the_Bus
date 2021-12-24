using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class SpeedAchieve : MonoBehaviour
{
    int countSpeedNum;
    static int temp;

    void Update()
    {
        /*
        if(!SteamManager.Initialized) { return; }

        SteamUserStats.RequestCurrentStats();

        SteamUserStats.GetStat("SPEEDNUM_COUNT", out countSpeedNum);
        Debug.Log(countSpeedNum);

        if(countSpeedNum == 20) { SteamUserStats.SetAchievement("BUS_FLY"); }

        SteamUserStats.StoreStats();
        */

    }

    public static void UpdateStats()
    {
        SteamUserStats.RequestCurrentStats();

        SteamUserStats.GetStat("SPEEDNUM_COUNT", out temp);
        temp += 1;
        SteamUserStats.SetStat("SPEEDNUM_COUNT", temp);
        
        if(temp == 20) { SteamUserStats.SetAchievement("BUS_FLY"); }
        SteamUserStats.StoreStats();
    }
}
