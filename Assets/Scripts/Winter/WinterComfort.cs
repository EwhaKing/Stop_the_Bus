using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinterComfort : MonoBehaviour
{
    public static int comfort;

    int NumOfPass;
    int[] ListOfNumPass;
    int num = data.WinterBusStopNum;

    string n;
    
    WinterCustomer overline;  //comfort line을 넘어설 때 사용할 오브젝트
    WinterCustomer[] insign;    //버스 정류장 사인 안에 있을 때 사용할 오브젝트
    bool check;

    float time;

    void Start()
    {
        comfort = 100;
        time = 0;

        WinterAssign Cus = GameObject.Find("Map_Winter").GetComponent<WinterAssign>();
        ListOfNumPass = Cus.EachPass;        //정류장 랜덤 손님 수 배열 가져오기

        insign = new WinterCustomer[num];
        for (int i = 0; i < insign.Length; i++)
            insign[i] = GameObject.Find(string.Format("BusStopSign{0}", i + 1)).GetComponent<WinterCustomer>();

        check = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Comfort_Line")
        {

            n = other.gameObject.transform.parent.name;

            if (n == "BusStopSign1")
                NumOfPass = ListOfNumPass[0];
            else if (n == "BusStopSign2")
                NumOfPass = ListOfNumPass[1];
            else if (n == "BusStopSign3")
                NumOfPass = ListOfNumPass[2];
            else if (n == "BusStopSign4")
                NumOfPass = ListOfNumPass[3];

            overline = other.gameObject.transform.parent.GetComponent<WinterCustomer>();

            if (overline.Taken())
            {
                if (!overline.GetMinusCom())
                {
                    comfort -= NumOfPass * 5;
                    overline.SetMinusCom();
                }
            }
        }
    }

    private void Update()
    {
        // 버스가 정류장 점선 내에 있는지 확인
        check = false;
        for (int i = 0; i < insign.Length; i++)
            check = check || insign[i].InSign();

        if (bus.speed == 0) //버스 속도가 5초 동안 0이면 만족도 줄도록
        {
            if (!check)     //버스 정류장 사인 내에서는 안 줄도록
            {
                time += Time.deltaTime;
                if (time >= 6)
                {
                    comfort--;
                    time = 5f;
                }
            }
        }
        else
            time = 0;   //속도가 0이 아니면 다시 시간 카운트 0으로 설정
        Debug.Log("comfort : " + comfort);
    }

    public static int GetComfort()
    {
        return comfort;
    }
}
