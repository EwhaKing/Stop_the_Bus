using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallAssign : MonoBehaviour
{
    static int StopNum = data.FallBusStopNum;   //가을 버스 정류장 수
    int PassengerNum = data.passenger;          //맵당 전체 손님 수 가져오기
    public int[] EachPass = new int[StopNum];   //정류장당 손님 수 저장할 배열

    void Awake()
    {
        int n = PassengerNum;
        int i;

        for (i = 0; i < StopNum; i++)   //정류장에 손님수 랜덤으로 할당
        {
            if (i == StopNum - 1)
                EachPass[i] = n;
            else
            {
                EachPass[i] = Random.Range(1, n - (StopNum - i) + 1);
                n -= EachPass[i];
            }
            Debug.Log(string.Format("{0}번 정류장 손님 수는 {1}입니다.", i + 1, EachPass[i]));     // 나중에 지우자
        }
    }
}
