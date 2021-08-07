using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialTotal : MonoBehaviour
{
    TutorialCustomer obj;
    public TextMeshProUGUI customerText;
    public static int SumOfCus;     //손님 합계
    private int count;              //손님 수 한 번만 더하기

    void Start()
    {
        customerText = gameObject.GetComponent<TextMeshProUGUI>();

        obj = GameObject.Find("BusStopSign").GetComponent<TutorialCustomer>();
        SumOfCus = 0;
        count = 0;
    }

    void Update()
    {
        if (!obj.Taken() && count == 0)
        {
            SumOfCus += TutorialCustomer.Tutopassenger;
            count++;
            Debug.Log(string.Format("{0}번 버스 정류장 {1}명 태워서 총 {2}명", name, TutorialCustomer.Tutopassenger, SumOfCus));
        }

        customerText.text = SumOfCus.ToString();
    }
}
