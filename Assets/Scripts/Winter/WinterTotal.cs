using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinterTotal : MonoBehaviour
{
    WinterAssign Cus;
    private int[] ListOfNumPass;

    WinterCustomer[] obj;
    int num = data.WinterBusStopNum;

    public TextMeshProUGUI customerText;
    public static int SumOfCus;     //손님 합계
    private int count;              //손님 수 한 번만 더하기


    void Start()
    {
        customerText = gameObject.GetComponent<TextMeshProUGUI>();

        Cus = GameObject.Find("Map_Winter").GetComponent<WinterAssign>();
        ListOfNumPass = Cus.EachPass;        //정류장 랜덤 손님 수 배열 가져오기

        obj = new WinterCustomer[num];
        obj[0] = GameObject.Find("BusStopSign1").GetComponent<WinterCustomer>();
        obj[1] = GameObject.Find("BusStopSign2").GetComponent<WinterCustomer>();
        obj[2] = GameObject.Find("BusStopSign3").GetComponent<WinterCustomer>();
        obj[3] = GameObject.Find("BusStopSign4").GetComponent<WinterCustomer>();

        SumOfCus = 0;
        count = 0;
    }

    void Update()
    {
        for (int i = 0; i < obj.Length; i++)
            if (!obj[i].Taken() && count == i)
            {
                SumOfCus += ListOfNumPass[i];
                count++;
                Debug.Log(string.Format("{0}번 버스 정류장 {1}명 태워서 총 {2}명", i, ListOfNumPass[i], SumOfCus));
            }

        customerText.text = SumOfCus.ToString();
    }
}
