using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringAssign : MonoBehaviour
{
    static int StopNum = 3; //봄 버스 정류장 수
    int PassengerNum = 20;  //전체 승객수
    public int[] EachPass = new int[StopNum];   //정류장당 손님 수 저장할 배열

    void Awake()
    {
        int n;
        int a = 1, b = 1, c = 1;
        int x, y, z;

        while (a + b + c < PassengerNum)
        {
            n = PassengerNum - (a + b + c);
            x = Random.Range(0, 11 - a);
            if (n - x > 10 - b)
            {
                y = Random.Range(0, 11 - b);
                if (n - x - y > 10 - c)
                    z = Random.Range(0, 11 - c);
                else
                    z = n - x - y;
            }
            else
            {
                y = Random.Range(0, n - x + 1);
                z = n - x - y;
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
