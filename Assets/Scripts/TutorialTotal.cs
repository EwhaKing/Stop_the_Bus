using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialTotal : MonoBehaviour
{
    TutorialCustomer obj;
    
    public TextMeshProUGUI customerText;
    public static int SumOfCus;     //손님 합계
    
    public GameObject Bus;
    public static GameObject[] Child;

    void Start()
    {
        SumOfCus = 0;

        customerText = gameObject.GetComponent<TextMeshProUGUI>();

        obj = GameObject.Find("BusStopSign").GetComponent<TutorialCustomer>();

        Child = new GameObject[8];
        for (int i = 0; i < Child.Length; i++) 
            Child[i] = Bus.transform.Find(string.Format("customerSit{0}", i + 1)).gameObject;
    }

    void Update()
    {
        customerText.text = SumOfCus.ToString();
    }

    public static void ActiveCustomer(int num)
    {
        int count = 0;
        for (int i = 0; i < 8; i++)
        {
            if (Child[i].activeSelf)
                count++;
        }

        if (num <= 8)
        {
            for (int i = 0; i < num - count; i++)
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
