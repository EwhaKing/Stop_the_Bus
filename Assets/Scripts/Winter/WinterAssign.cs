using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinterAssign : MonoBehaviour
{
    static int StopNum = data.WinterBusStopNum;   //겨울 버스 정류장 수
    int PassengerNum = data.passenger;          //맵당 전체 손님 수 가져오기
    public int[] EachPass = new int[StopNum];   //정류장당 손님 수 저장할 배열

    void Awake()
    {
        /*
        int n = PassengerNum;
        int i;

        for (i = 0; i < StopNum; i++)   //정류장에 손님수 랜덤으로 할당
        {
            if (i == StopNum - 1)
                EachPass[i] = n;
            else
            {
                if(i == 1 && n > 15)
                    EachPass[i] = Random.Range(1, 15);
                else if (i == 2 && n > 13)
                    EachPass[i] = Random.Range(1, 14);
                else
                    EachPass[i] = Random.Range(1, n - (StopNum - i) + 1);
                n -= EachPass[i];
            }
        }
        */

        int n;
        int a = 1, b = 1, c = 1, d = 1;
        int x, y, z, p;

        while(a + b + c + d < PassengerNum)
        {
            n = PassengerNum - (a + b + c + d);
            x = Random.Range(0, 11 - a);
            if (n - x > 10 - b)
            {
                y = Random.Range(0, 11 - b);
                if(n - x - y > 10 - c)
                {
                    z = Random.Range(0, 11 - c);
                    if (n - x - y - z > 10 - d)
                        p = Random.Range(0, 11 - d);
                    else
                        p = n - x - y - z;
                }
                else
                {
                    z = Random.Range(0, n - x - y + 1);
                    p = n - x - y - z;
                }
            }
            else
            {
                y = Random.Range(0, n - x + 1);
                z = Random.Range(0, n - x - y + 1);
                p = n - x - y - z;
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
