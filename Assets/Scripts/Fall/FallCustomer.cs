using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCustomer : MonoBehaviour
{
    public GameObject[] person;   //손님 오브젝트
    private List<GameObject> passengers = new List<GameObject>();   //손님 오브젝트 배열

    int[] ListOfNumPass;        //정류장 손님수 배열
    int NumOfPass;              //각 정류장마다 손님수를 저장할 변수

    float timeCount;
    string wheel;
    bool wheel1, wheel2, wheel3, wheel4;
    private bool eachtaken;     //손님 탑승 체크 변수
    private bool insign;        //버스 스탑 점선 안에 있는지 체크할 변수
    private bool minusCom;      //정류장을 넘어서서 만족도가 깎였는지 체크할 변수
    private bool sumCheck;      //손님 태워서 합계 더했는지 확인

    AudioSource audioSource;
    public AudioClip customerIng;
    public AudioClip customerEnd;
    float soundCount = 0;       //손님 태울 때 시간 카운트
    int TakenSound = 0;         //손님 다 태우고 났을 때 사운드 

    void Start()
    {
        FallAssign Cus = GameObject.Find("Map_fall").GetComponent<FallAssign>();
        ListOfNumPass = Cus.EachPass;        //정류장 랜덤 손님 수 배열 가져오기
        string name = this.gameObject.name;     //오브젝트 이름
        audioSource = GetComponent<AudioSource>();

        //버스 정류장 수에 따라 수정 필요
        if (name == "BusStopSign1")
            NumOfPass = ListOfNumPass[0];
        else if (name == "BusStopSign2")
            NumOfPass = ListOfNumPass[1];
        else if (name == "BusStopSign3")
            NumOfPass = ListOfNumPass[2];
        else if (name == "BusStopSign4")
            NumOfPass = ListOfNumPass[3];

        timeCount = 4 * NumOfPass;      //각 바퀴 콜라이더마다 계산해서 4 곱해야 함


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

        wheel1 = false;
        wheel2 = false;
        wheel3 = false;
        wheel4 = false;
        eachtaken = true;
        insign = false;
        minusCom = false;
        sumCheck = false;
    }

    void Update()
    {
        if (insign && bus.speed == 0 && eachtaken)
        {
            soundCount += Time.deltaTime;
            if (soundCount >= 1f)
            {
                audioSource.clip = customerIng;
                audioSource.Play();
                soundCount = 0;
            }
        }

        if (insign && bus.speed == 0 && !eachtaken)
            if (TakenSound == 0)
            {
                audioSource.clip = customerEnd;
                audioSource.Play();
                TakenSound++;
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

        if (wheel1 && wheel2 && wheel3 && wheel4)   // 네 바퀴가 모두 점선과 접촉해있을 때
        {
            insign = true;
            if (bus.speed == 0)     // 버스 속도가 0이어야        
            {
                if (timeCount > 0)
                    timeCount -= Time.deltaTime;
            }
            else
                timeCount = 4 * NumOfPass;

        }


        if (timeCount <= 0 && eachtaken)
        {
            eachtaken = false;

            //손님 오브젝트 삭제
            foreach (var child in passengers)
                Destroy(child.gameObject);

        }

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
        {
            insign = false;
            if (eachtaken)
                timeCount = 4 * NumOfPass;
        }
    }

    public bool Taken()     //손님 탑승 완료 반환 함수
    {
        return eachtaken;
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

    public void SetSumCheck()
    {
        sumCheck = true;
    }

    public bool GetSumCheck()
    {
        return sumCheck;
    }
}
