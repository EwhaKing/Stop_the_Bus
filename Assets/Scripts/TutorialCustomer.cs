using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCustomer : MonoBehaviour
{
    public static int Tutopassenger;
    public GameObject[] person;
    private List<GameObject> passengers = new List<GameObject>();   //손님 오브젝트 배열

    float timeCount;    //손님 태울 때 시간 카운트
    float WaitTime;       //손님 태우기 전 2초간 기다리기
    float TakeCusTime;

    string wheel;
    bool wheel1, wheel2, wheel3, wheel4;    //바퀴가 점선과 접촉해 있는지 확인할 변수

    private bool NotTaken;     //손님 탑승 체크 변수
    private bool MoveInLine;    //점선 안에서 손님을 태우다가 움직였을 때 사용할 변수
    private bool insign;        //버스 스탑 점선 안에 있는지 체크할 변수

    AudioSource audioSource;
    public AudioClip customerIng;
    public AudioClip customerEnd;
    float soundCount = 0;       //손님 태울 때 시간 카운트
    int TakenSound = 0;         //손님 다 태우고 났을 때 사운드 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Tutopassenger = 5;
        timeCount = Tutopassenger;

        TakeCusTime = 0;
        WaitTime = 0;
        MoveInLine = false;
        wheel1 = false;
        wheel2 = false;
        wheel3 = false;
        wheel4 = false;
        NotTaken = true;
        insign = false;

        for (int i = 0; i < Tutopassenger; i++)
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
    }

    void Update()
    {
        if (wheel1 && wheel2 && wheel3 && wheel4)   // 네 바퀴가 모두 점선과 접촉해있을 때
        {
            insign = true;
            if (bus.speed == 0)     // 버스 속도가 0이어야        
            {
                MoveInLine = true;
                if (WaitTime > 0)
                    WaitTime -= Time.deltaTime;
                else
                {
                    if (timeCount > 0)
                    {
                        timeCount -= Time.deltaTime;
                        TakeCusTime += Time.deltaTime;
                        if (TakeCusTime >= 1f)
                        {
                            TakeCusTime = 0;
                            TutorialTotal.SumOfCus++;
                            TutorialTotal.ActiveCustomer(TutorialTotal.SumOfCus);
                            Destroy(passengers[passengers.Count - 1]);
                            passengers.RemoveAt(passengers.Count - 1);
                        }
                    }
                }
            }
        }


        if (timeCount <= 0 && NotTaken)
            NotTaken = false;


        if (insign && NotTaken)
        {
            if (bus.speed == 0)
            {
                soundCount += Time.deltaTime;
                if (soundCount >= 1f)
                {
                    audioSource.clip = customerIng;
                    audioSource.Play();
                    soundCount = 0;
                }

            }
            else
            {
                if (MoveInLine)
                {
                    WaitTime = 2;
                    MoveInLine = false;
                }
            }
        }

        if (insign && bus.speed == 0 && !NotTaken)
            if (TakenSound == 0)
            {
                if (passengers.Count != 0)
                {
                    TutorialTotal.SumOfCus++;
                    TutorialTotal.ActiveCustomer(TutorialTotal.SumOfCus);
                    Destroy(passengers[0]);
                    passengers.RemoveAt(0);
                }
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
            if (NotTaken)
                timeCount = Tutopassenger;
        }
    }

    public bool Taken()     //손님 탑승 완료 반환 함수
    {
        return NotTaken;
    }

}
