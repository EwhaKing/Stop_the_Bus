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

    GameObject Parent;
    GameObject[] Child;

    void Start()
    {
        customerText = gameObject.GetComponent<TextMeshProUGUI>();

        obj = GameObject.Find("BusStopSign").GetComponent<TutorialCustomer>();

        Parent = GameObject.FindWithTag("Bus");
        Child = new GameObject[8];
        for (int i = 0; i < Child.Length; i++)
            Child[i] = Parent.transform.Find(string.Format("customerSit{0}", i + 1)).gameObject;

        SumOfCus = 0;
        count = 0;
    }

    void Update()
    {
        if (!obj.Taken() && count == 0)
        {
            SumOfCus += TutorialCustomer.Tutopassenger;
            ActiveCustomer(SumOfCus);
            count++;
        }

        customerText.text = SumOfCus.ToString();
    }

    void ActiveCustomer(int num)
    {
        if (num <= 8)
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
