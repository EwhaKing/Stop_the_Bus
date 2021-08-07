using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinterNeedToPass : MonoBehaviour
{
    bool[] pass;
    public static bool end;
    string passname;
    GameObject endsign;

    void Start()
    {
        pass = new bool[7];     //통과해야하는 콜라이더 수 배열 생성
        end = true;

        for (int i = 0; i < pass.Length; i++)
            pass[i] = false;

        endsign = GameObject.Find("BusStopSign(Red)").gameObject;
        endsign.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        passname = other.gameObject.name;

        if (passname == "Pass1")
            pass[0] = true;
        else if (passname == "Pass2")
            pass[1] = true;
        else if (passname == "Pass3")
            pass[2] = true;
        else if (passname == "Pass4")
            pass[3] = true;
        else if (passname == "Pass5")
            pass[4] = true;
        else if (passname == "Pass6")
            pass[5] = true;
        else if (passname == "Pass7")
            pass[6] = true;
    }

    void Update()
    {
        end = true;
        for (int i = 0; i < pass.Length; i++)
            end = end && pass[i];
        Debug.Log("end : " + end);

        if (end)
            endsign.SetActive(true);
    }
}
