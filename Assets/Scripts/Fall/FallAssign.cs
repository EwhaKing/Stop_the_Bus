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
        /*
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
                EachPass[i] = Random.Range(1, n - i + 1);
            n -= EachPass[i];
        }
        */

        int n;
        int a = 1, b = 1, c = 1, d = 1;
        int x, y, z, p;

        while(a + b + c + d < PassengerNum)
        {
            n = PassengerNum - (a + b + c + d);
            p = Random.Range(0, 8 - d);
            if(n - p > 10 - c)
            {
                z = Random.Range(0, 11 - c);
                if(n - p - z > 10 - b)
                {
                    y = Random.Range(0, 11 - b);
                    if (n - p - z - y > 10 - a)
                        x = Random.Range(0, 11 - a);
                    else
                        x = n - p - z - y;
                }
                else
                {
                    y = Random.Range(0, n - p - z + 1);
                    x = n - p - z - y;
                }
            }
            else
            {
                z = Random.Range(0, n - p + 1);
                y = Random.Range(0, n - p - z + 1);
                x = n - p - z - y;
            }

            a += x;
            b += y;
            c += z;
            d += p;
        }

        EachPass[0] = a;
        EachPass[1] = b;
        EachPass[2] = c;
        EachPass[3] = d;

        Debug.Log("첫번째 정류장 : " + EachPass[0] + "명");
        Debug.Log("두번째 정류장 : " + EachPass[1] + "명");
        Debug.Log("세번째 정류장 : " + EachPass[2] + "명");
        Debug.Log("네번째 정류장 : " + EachPass[3] + "명");
    }
}
