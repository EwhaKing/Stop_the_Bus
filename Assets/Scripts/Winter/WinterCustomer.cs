using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinterCustomer : MonoBehaviour
{
    public GameObject[] person;   //손님 오브젝트
    private List<GameObject> passengers = new List<GameObject>();   //손님 오브젝트 배열

    int[] ListOfNumPass;        //정류장 손님수 배열
    int NumOfPass;              //각 정류장마다 손님수를 저장할 변수

    float timeCount;    //손님 태울 때 시간 카운트
    float WaitTime;       //손님 태우기 전 2초간 기다리기
    float TakeCusTime;

    string wheel;
    bool wheel1, wheel2, wheel3, wheel4;
    private bool NotTaken;     //손님 탑승 체크 변수
    private bool insign;        //버스 스탑 점선 안에 있는지 체크할 변수
    private bool minusCom;      //정류장을 넘어서서 만족도가 깎였는지 체크할 변수
    private bool MoveInLine;    //점선 안에서 손님을 태우다가 움직였을 때 사용할 변수

    AudioSource audioSource;
    public AudioClip customerIng;
    public AudioClip customerEnd;
    public AudioClip Annoyed;
    public GameObject Annoying; //궁시렁 오브젝트 
    bool AnnoyingCount;       //궁시렁 한번
    float AnnoyingTime = 0;          //손님 한명도 안태우고 떠났을 때 말풍선 시간
    int TakenSound = 0;         //손님 다 태우고 났을 때 사운드 

    void Start()
    {
        WinterAssign Cus = GameObject.Find("Map_Winter").GetComponent<WinterAssign>();
        ListOfNumPass = Cus.EachPass;        //정류장 랜덤 손님 수 배열 가져오기
        string name = this.gameObject.name;     //오브젝트 이름
        audioSource = GetComponent<AudioSource>();

        if (name == "BusStopSign1")
            NumOfPass = ListOfNumPass[0];
        else if (name == "BusStopSign2")
            NumOfPass = ListOfNumPass[1];
        else if (name == "BusStopSign3")
            NumOfPass = ListOfNumPass[2];
        else if (name == "BusStopSign4")
            NumOfPass = ListOfNumPass[3];

        timeCount = NumOfPass;


        for (int i = 0; i < NumOfPass; i++)
        {
            int size = Random.Range(0, person.Length);

            GameObject per = Instantiate(person[size], this.transform.position, Quaternion.identity);
            per.transform.parent = this.gameObject.transform;
            if (size == 0)
                per.transform.localScale = new Vector3(0.0629103f, 0.04913933f, 0.01258207f);
            else if (size == 1)
                per.transform.localScale = new Vector3(0.04886299f, 0.02624385f, 0.03085691f);
            else if (size == 2)
                per.transform.localScale = new Vector3(0.04735571f, 0.02543431f, 0.02990506f);
            else
                per.transform.localScale = new Vector3(0.04570316f, 0.02454673f, 0.02886147f);
            per.transform.localRotation = Quaternion.Euler(0, 0, 90);
            per.transform.localPosition = new Vector3(0.006f - 0.0025f * i, 0.0065f, 0.0007f);
            passengers.Add(per);
        }

        TakeCusTime = 0;
        WaitTime = 0;
        AnnoyingCount = false;
        MoveInLine = false;
        wheel1 = false;
        wheel2 = false;
        wheel3 = false;
        wheel4 = false;
        NotTaken = true;
        insign = false;
        minusCom = false;
    }

    void Update()
    {
        if (insign && NotTaken)
        {
            if (bus.sss == 0)
            {
                MoveInLine = true;
                if (WaitTime > 0)
                {
                    WaitTime -= Time.deltaTime;
                    if (AnnoyingCount)
                    {
                        audioSource.Play();
                        AnnoyingCount = false;
                    }
                }
                else
                {
                    Annoying.SetActive(false);
                    if (timeCount > 0)
                    {
                        timeCount -= Time.deltaTime;
                        TakeCusTime += Time.deltaTime;
                        if (TakeCusTime >= 1f)
                        {
                            TakeCusTime = 0;
                            audioSource.clip = customerIng;
                            audioSource.Play();
                            WinterTotal.SumOfCus++;
                            WinterTotal.ActiveCustomer(WinterTotal.SumOfCus);
                            Destroy(passengers[0]);
                            passengers.RemoveAt(0);
                            foreach (GameObject pas in passengers)
                                pas.transform.localPosition =
                                    new Vector3(pas.transform.localPosition.x + 0.0025f, pas.transform.localPosition.y, pas.transform.localPosition.z);
                        }
                    }
                }
            }
            else
            {
                if (MoveInLine)
                {
                    WaitTime = 2;
                    Annoying.SetActive(true);
                    AnnoyingCount = true;
                    MoveInLine = false;
                    timeCount = Mathf.Ceil(timeCount);
                    TakeCusTime = 0;
                    audioSource.clip = Annoyed;
                }
            }
        }

        if (!insign && NotTaken && AnnoyingCount && Annoying.activeSelf)
        {
            Annoying.SetActive(false);
            AnnoyingCount = false;
        }


        if (insign && bus.sss == 0 && !NotTaken)
        {
            if (TakenSound == 0)
            {
                if (passengers.Count != 0)
                {
                    WinterTotal.SumOfCus++;
                    WinterTotal.ActiveCustomer(TutorialTotal.SumOfCus);
                    Destroy(passengers[0]);
                    passengers.RemoveAt(0);
                }
                audioSource.clip = customerEnd;
                audioSource.Play();
                TakenSound++;
            }
        }

        if (timeCount <= 0)
            NotTaken = false;

        if (NotTaken && !insign && minusCom && AnnoyingCount)
        {
            Annoying.SetActive(true);
            AnnoyingTime += Time.deltaTime;
            if (AnnoyingTime > 1f)
            {
                Annoying.SetActive(false);
                AnnoyingCount = false;
            }
        }

    }

    void OnTriggerStay(Collider coll)
    {
        wheel = coll.gameObject.name;
        if (wheel == "BUS_wheelLB")
            wheel1 = true;
        else if (wheel == "BUS_wheelLF")
            wheel2 = true;
        else if (wheel == "BUS_wheelRB")
            wheel3 = true;
        else if (wheel == "BUS_wheelRF")
            wheel4 = true;

        if (wheel1 && wheel2 && wheel3 && wheel4)
            insign = true;
    }

    void OnTriggerExit(Collider coll)
    {
        wheel = coll.gameObject.name;
        if (wheel == "BUS_wheelLB")
            wheel1 = false;
        else if (wheel == "BUS_wheelLF")
            wheel2 = false;
        else if (wheel == "BUS_wheelRB")
            wheel3 = false;
        else if (wheel == "BUS_wheelRF")
            wheel4 = false;

        if (!(wheel1 && wheel2 && wheel3 && wheel4))
            insign = false;
    }

    public bool IsNotTaken()     //손님 탑승 완료 반환 함수
    {
        return NotTaken;
    }

    public bool InSign()    //정류장 점선 안에 버스가 있는지를 반환하는 함수
    {
        return insign;
    }

    public void SetMinusCom()   //정류장을 넘어서서 만족도가 깎였을 때 사용할 함수
    {
        minusCom = true;
    }

    public bool GetMinusCom()   //정류장을 넘어서서 만족도가 깎였는지 확인할 함수
    {
        return minusCom;
    }

    public int RemainCus()
    {
        return passengers.Count;
    }
}
