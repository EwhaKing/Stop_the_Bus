using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class SpeedAchieve : MonoBehaviour
{
    static int speedNum;

    public static void UpdateStats()
    {
        SteamUserStats.RequestCurrentStats();

        SteamUserStats.GetStat("SPEEDNUM_COUNT", out speedNum);
        speedNum += 1;
        SteamUserStats.SetStat("SPEEDNUM_COUNT", speedNum);
        
        if(speedNum == 20) { SteamUserStats.SetAchievement("BUS_FLY"); }
        SteamUserStats.StoreStats();
    }
}
