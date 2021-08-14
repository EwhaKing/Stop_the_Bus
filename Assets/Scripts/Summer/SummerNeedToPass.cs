using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummerNeedToPass : MonoBehaviour
{
    public int PassNum;
    bool[] pass;
    public static bool end;
    string passname;
    GameObject endsign;

    void Start()
    {
        pass = new bool[PassNum];     //통과해야하는 콜라이더 수 배열 생성
        end = true;

        for (int i = 0; i < pass.Length; i++)
            pass[i] = false;

        endsign = GameObject.Find("BusStopSign(Red)").gameObject;
        endsign.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        passname = other.gameObject.name;

        for (int i = 0; i < pass.Length; i++)
            if (passname == string.Format("Pass{0}", i + 1))
                pass[i] = true;
    }

    void Update()
    {
        end = true;
        for (int i = 0; i < pass.Length; i++)
            end = end && pass[i];

        if (end)
            endsign.SetActive(true);
    }
}
