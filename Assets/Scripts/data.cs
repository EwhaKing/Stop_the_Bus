using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class data : MonoBehaviour
{
    // Start is called before the first frame update
    public static int speed; //버스 속도
    public static int passenger = 20; //승객 수

    //계절 맵별 손님이 나타나는 버스 정류장 수
    public static int SpringBusStopNum = 3; //봄
    public static int SummerBusStopNum = 3; //여름
    public static int FallBusStopNum = 4;   //가을
    public static int WinterBusStopNum = 4; //겨울

    //볼륨상수
    public static float background = -10f;
    public static float effect = -10f;
    public static bool mute = false;
    void Awake(){
        //PlayerPrefs.SetString("lang","localizedText_kr");
    }
    // 더 추가할 거 있으면 추가하셔요~
}
