using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SummerTotal : MonoBehaviour
{
    SummerAssign Cus;
    private int[] ListOfNumPass;

    SummerCustomer[] obj;
    int num = data.SummerBusStopNum;

    public TextMeshProUGUI customerText;
    public static int SumOfCus;     //손님 합계

    GameObject Parent;
    GameObject[] Child;


    void Start()
    {
        customerText = gameObject.GetComponent<TextMeshProUGUI>();

        Cus = GameObject.Find("Map_Summer").GetComponent<SummerAssign>();
        ListOfNumPass = Cus.EachPass;        //정류장 랜덤 손님 수 배열 가져오기

        obj = new SummerCustomer[num];
        for(int i = 0; i < obj.Length; i++)
            obj[i] = GameObject.Find(string.Format("BusStopSign{0}", i + 1)).GetComponent<SummerCustomer>();

        Parent = GameObject.FindWithTag("Bus");
        Child = new GameObject[8];
        for(int i = 0; i < Child.Length; i++)
            Child[i] = Parent.transform.Find(string.Format("customerSit{0}", i + 1)).gameObject;

        SumOfCus = 0;
    }

    void Update()
    {
        for (int i = 0; i < obj.Length; i++)
            if (!obj[i].Taken() && !obj[i].GetSumCheck())
            {
                obj[i].SetSumCheck();
                SumOfCus += ListOfNumPass[i];
                ActiveCustomer(SumOfCus);
            }

        customerText.text = SumOfCus.ToString();
    }

    void ActiveCustomer(int num)
    {
        if(num <= 8)
        {
            for (int i = 0; i < num; i++)
            {
                int rand = Random.Range(0, 8);
                if (Child[rand].activeSelf)
                    i--;
                else
                    Child[rand].SetActive(true);

            }
        }
        else
        {
            for (int i = 0; i < 8; i++)
                Child[i].SetActive(true);
        }
    }
}
