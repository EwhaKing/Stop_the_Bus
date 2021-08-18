using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringAssign : MonoBehaviour
{
    static int StopNum = data.SpringBusStopNum; //봄 버스 정류장 수
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
                if (i == 1 && n > 15)
                    EachPass[i] = Random.Range(1, 16);
                else
                    EachPass[i] = Random.Range(1, n - (StopNum - i) + 1);
                n -= EachPass[i];
            }
            Debug.Log(string.Format("{0}번 {1}명", i, EachPass[i]));
        }
    }
}
