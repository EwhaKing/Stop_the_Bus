using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummerAssign : MonoBehaviour
{
    static int StopNum = data.SummerBusStopNum; //여름 버스 정류장 수
    int PassengerNum = data.passenger;          //맵당 전체 손님 수 가져오기
    public int[] EachPass = new int[StopNum];   //정류장당 손님 수 저장할 배열

    void Awake()
    {
        /*
        int n = PassengerNum;
        int i;

        //여름 정류장 뒷번호 부터
        for (i = StopNum - 1; i >= 0; i--)   //정류장에 손님수 랜덤으로 할당
        {
            if (i == StopNum - 1)
                EachPass[i] = Random.Range(1, 10);
            else if (i == 0)
                EachPass[i] = n;
            else
                EachPass[i] = Random.Range(1, n - i + 1);
            n -= EachPass[i];
        }
        */

        int n;
        int a = 1, b = 1, c = 1;
        int x, y, z;

        //c부터 배정. 3번 정류장은 9명까지.
        while(a + b + c < PassengerNum)
        {
            n = PassengerNum - (a + b + c);
            z = Random.Range(0, 10 - c);
            if(n - z > 10 - b)
            {
                y = Random.Range(0, 11 - b);
                if (n - z - y > 10 - a)
                    x = Random.Range(0, 11 - a);
                else
                    x = n - z - y;
            }
            else
            {
                y = Random.Range(0, n - z + 1);
                x = n - z - y;
            }

            a += x;
            b += y;
            c += z;
        }

        EachPass[0] = a;
        EachPass[1] = b;
        EachPass[2] = c;

        //Debug.Log("첫번째 정류장 : " + EachPass[0] + "명");
        //Debug.Log("두번째 정류장 : " + EachPass[1] + "명");
        //Debug.Log("세번째 정류장 : " + EachPass[2] + "명");
    }
}
