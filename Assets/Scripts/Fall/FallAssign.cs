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

        for (i = StopNum - 1; i >= 0; i--)   //정류장에 손님수 랜덤으로 할당
        {
            if (i == StopNum - 1)
                EachPass[i] = Random.Range(1, 8);
            else if (i == StopNum - 2)
                EachPass[i] = Random.Range(1, 11);
            else if (i == 0)
                EachPass[i] = n;
            else
                EachPass[i] = Random.Range(1, n - i);
            n -= EachPass[i];
        }
    }
}
