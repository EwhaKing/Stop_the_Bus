using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpringTotal : MonoBehaviour
{
    SpringAssign Cus;
    private int[] ListOfNumPass;

    SpringCustomer[] obj;
    int num = data.SpringBusStopNum;

    public TextMeshProUGUI customerText;
    public static int SumOfCus;     //손님 합계
    private int count;              //손님 수 한 번만 더하기


    void Start()
    {
        customerText = gameObject.GetComponent<TextMeshProUGUI>();

        Cus = GameObject.Find("Map_Spring").GetComponent<SpringAssign>();
        ListOfNumPass = Cus.EachPass;        //정류장 랜덤 손님 수 배열 가져오기

        obj = new SpringCustomer[num];
        obj[0] = GameObject.Find("BusStopSign1").GetComponent<SpringCustomer>();
        obj[1] = GameObject.Find("BusStopSign2").GetComponent<SpringCustomer>();
        obj[2] = GameObject.Find("BusStopSign3").GetComponent<SpringCustomer>();

        SumOfCus = 0;
        count = 0;
    }

    void Update()
    {
        if (!obj[0].Taken() && count == 0)
        {
            SumOfCus += ListOfNumPass[0];
            count++;
            Debug.Log(string.Format("{0}번 버스 정류장 {1}명 태워서 총 {2}명", name, ListOfNumPass[0], SumOfCus));
        }
        else if (!obj[1].Taken() && count == 1)
        {
            SumOfCus += ListOfNumPass[1];
            count++;
            Debug.Log(string.Format("{0}번 버스 정류장 {1}명 태워서 총 {2}명", name, ListOfNumPass[1], SumOfCus));
        }
        else if (!obj[2].Taken() && count == 2)
        {
            SumOfCus += ListOfNumPass[2];
            count++;
            Debug.Log(string.Format("{0}번 버스 정류장 {1}명 태워서 총 {2}명", name, ListOfNumPass[2], SumOfCus));
        }

        customerText.text = SumOfCus.ToString();
    }
}
