using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bump : MonoBehaviour
{
    private int speedBump; // 방지턱 위반 속도 4가지
    public GameObject obj30; // 표지판 30
    public GameObject obj40; // 표지판 40
    public GameObject obj50; // 표지판 50
    public GameObject obj60; // 표지판 60
    public AudioClip audioBump;
    public GameObject bump; // 방지턱
    private int rand;

    AudioSource audioSource;
    public Rigidbody rd;

    void Start()
    {
        rand = Random.Range(3, 7); // 변수에 랜덤으로 3, 4, 5, 6 저장

        // 속도 지정 및 표지판 생성
        if (bump.CompareTag("SpringBump1"))
        {
            switch (rand)
            {
                case 3:
                    speedBump = 30;
                    Instantiate(obj30, new Vector3(6.7f, 0.19f, 25.08f), Quaternion.Euler(-90.0f, 0, 0));
                    break;
                case 4:
                    speedBump = 40;
                    Instantiate(obj40, new Vector3(6.7f, 0.19f, 25.08f), Quaternion.Euler(-90.0f, 0, 0));
                    break;
                case 5:
                    speedBump = 50;
                    Instantiate(obj50, new Vector3(6.7f, 0.19f, 25.08f), Quaternion.Euler(0, 0, 0));
                    break;
                case 6:
                    speedBump = 60;
                    Instantiate(obj60, new Vector3(6.7f, 0.19f, 25.08f), Quaternion.Euler(-90.0f, 0, 0));
                    break;
            }
        }
        else if (bump.CompareTag("SpringBump2"))
        {
            switch (rand)
            {
                case 3:
                    speedBump = 30;
                    Instantiate(obj30, new Vector3(22.81f, 7.651f, -24.56f), Quaternion.Euler(-90.0f, 180.0f, -45.0f));
                    break;
                case 4:
                    speedBump = 40;
                    Instantiate(obj40, new Vector3(22.81f, 7.651f, -24.56f), Quaternion.Euler(-90.0f, 180.0f, -45.0f));
                    break;
                case 5:
                    speedBump = 50;
                    Instantiate(obj50, new Vector3(22.81f, 7.651f, -24.56f), Quaternion.Euler(0, 135.0f, 0));
                    break;
                case 6:
                    speedBump = 60;
                    Instantiate(obj60, new Vector3(22.81f, 7.651f, -24.56f), Quaternion.Euler(-90.0f, 180.0f, -45.0f));
                    break;
            }
        }
        else if (bump.CompareTag("SpringBump3"))
        {
            switch (rand)
            {
                case 3:
                    speedBump = 30;
                    Instantiate(obj30, new Vector3(-12.29f, 0.179f, -26.64f), Quaternion.Euler(-90.0f, 180.0f, 0));
                    break;
                case 4:
                    speedBump = 40;
                    Instantiate(obj40, new Vector3(-12.29f, 0.179f, -26.64f), Quaternion.Euler(-90.0f, 180.0f, 0));
                    break;
                case 5:
                    speedBump = 50;
                    Instantiate(obj50, new Vector3(-12.29f, 0.179f, -26.64f), Quaternion.Euler(0, 180.0f, 0));
                    break;
                case 6:
                    speedBump = 60;
                    Instantiate(obj60, new Vector3(-12.29f, 0.179f, -26.64f), Quaternion.Euler(-90.0f, 180.0f, 0));
                    break;
            }
        }
        else if (bump.CompareTag("SpringBump4"))
        {
            switch (rand)
            {
                case 3:
                    speedBump = 30;
                    Instantiate(obj30, new Vector3(-25.79f, 0.16f, -14.35f), Quaternion.Euler(-90.0f, -90.0f, -45.0f));
                    break;
                case 4:
                    speedBump = 40;
                    Instantiate(obj40, new Vector3(-25.79f, 0.16f, -14.35f), Quaternion.Euler(-90.0f, -90.0f, -45.0f));
                    break;
                case 5:
                    speedBump = 50;
                    Instantiate(obj50, new Vector3(-25.79f, 0.16f, -14.35f), Quaternion.Euler(0, 225.0f, 0));
                    break;
                case 6:
                    speedBump = 60;
                    Instantiate(obj60, new Vector3(-25.79f, 0.16f, -14.35f), Quaternion.Euler(-90.0f, -90.0f, -45.0f));
                    break;
            }
        }
        else if (bump.CompareTag("SummerBump1"))
        {
            switch (rand)
            {
                case 3:
                    speedBump = 30;
                    Instantiate(obj30, new Vector3(37.67f, 0.453f, 37.01f), Quaternion.Euler(-90.0f, -90.0f, 0));
                    break;
                case 4:
                    speedBump = 40;
                    Instantiate(obj40, new Vector3(37.67f, 0.453f, 37.01f), Quaternion.Euler(-90.0f, -90.0f, 0));
                    break;
                case 5:
                    speedBump = 50;
                    Instantiate(obj50, new Vector3(37.67f, 0.453f, 37.01f), Quaternion.Euler(0, -90.0f, 0));
                    break;
                case 6:
                    speedBump = 60;
                    Instantiate(obj60, new Vector3(37.67f, 0.453f, 37.01f), Quaternion.Euler(-90.0f, -90.0f, 0));
                    break;
            }
        }
        else if(bump.CompareTag("SummerBump2"))
        {
            switch (rand)
            {
                case 3:
                    speedBump = 30;
                    Instantiate(obj30, new Vector3(-3.195f, 12.118f, 8.185f), Quaternion.Euler(-122.0f, 270.0f, -90.0f));
                    break;
                case 4:
                    speedBump = 40;
                    Instantiate(obj40, new Vector3(-3.195f, 12.118f, 8.185f), Quaternion.Euler(-122.0f, 270.0f, -90.0f));
                    break;
                case 5:
                    speedBump = 50;
                    Instantiate(obj50, new Vector3(-3.195f, 12.118f, 8.185f), Quaternion.Euler(0, -180.0f, 32.0f));
                    break;
                case 6:
                    speedBump = 60;
                    Instantiate(obj60, new Vector3(-3.195f, 12.118f, 8.185f), Quaternion.Euler(-122.0f, 270.0f, -90.0f));
                    break;
            }
        }
        else if(bump.CompareTag("SummerBump3"))
        {
            switch (rand)
            {
                case 3:
                    speedBump = 30;
                    Instantiate(obj30, new Vector3(-17.68f, 15.451f, 44.154f), Quaternion.Euler(-90.0f, 180.0f, 0));
                    break;
                case 4:
                    speedBump = 40;
                    Instantiate(obj40, new Vector3(-17.68f, 15.451f, 44.154f), Quaternion.Euler(-90.0f, 180.0f, 0));
                    break;
                case 5:
                    speedBump = 50;
                    Instantiate(obj50, new Vector3(-17.68f, 15.451f, 44.154f), Quaternion.Euler(0, 180.0f, 0));
                    break;
                case 6:
                    speedBump = 60;
                    Instantiate(obj60, new Vector3(-17.68f, 15.451f, 44.154f), Quaternion.Euler(-90.0f, 180.0f, 0));
                    break;
            }
        }
        else if(bump.CompareTag("SummerBump4"))
        {
            switch (rand)
            {
                case 3:
                    speedBump = 30;
                    Instantiate(obj30, new Vector3(8.8846f, 4.581f, -41.95f), Quaternion.Euler(-122.0f, -90.0f, 90.0f));
                    break;
                case 4:
                    speedBump = 40;
                    Instantiate(obj40, new Vector3(8.8846f, 4.581f, -41.95f), Quaternion.Euler(-122.0f, -90.0f, 90.0f));
                    break;
                case 5:
                    speedBump = 50;
                    Instantiate(obj50, new Vector3(8.8846f, 4.581f, -41.95f), Quaternion.Euler(0, 0, -32.0f));
                    break;
                case 6:
                    speedBump = 60;
                    Instantiate(obj60, new Vector3(8.8846f, 4.581f, -41.95f), Quaternion.Euler(-122.0f, -90.0f, 90.0f));
                    break;
            }
        }
        else if (bump.CompareTag("FallBump1"))
        {
            switch (rand)
            {
                case 3:
                    speedBump = 30;
                    Instantiate(obj30, new Vector3(19.2f, 0.152f, 10.18f), Quaternion.Euler(-90.0f, 0, 45.0f));
                    break;
                case 4:
                    speedBump = 40;
                    Instantiate(obj40, new Vector3(19.2f, 0.152f, 10.18f), Quaternion.Euler(-90.0f, 0, 45.0f));
                    break;
                case 5:
                    speedBump = 50;
                    Instantiate(obj50, new Vector3(19.2f, 0.152f, 10.18f), Quaternion.Euler(0, 45.0f, 0));
                    break;
                case 6:
                    speedBump = 60;
                    Instantiate(obj60, new Vector3(19.2f, 0.152f, 10.18f), Quaternion.Euler(-90.0f, 0, 45.0f));
                    break;
            }
        }
        else if (bump.CompareTag("FallBump2"))
        {
            switch (rand)
            {
                case 3:
                    speedBump = 30;
                    Instantiate(obj30, new Vector3(-36.7f, 0.321f, -21.2f), Quaternion.Euler(-90.0f, 0, 180.0f));
                    break;
                case 4:
                    speedBump = 40;
                    Instantiate(obj40, new Vector3(-36.7f, 0.321f, -21.2f), Quaternion.Euler(-90.0f, 0, 180.0f));
                    break;
                case 5:
                    speedBump = 50;
                    Instantiate(obj50, new Vector3(-36.7f, 0.321f, -21.2f), Quaternion.Euler(0, 180.0f, 0));
                    break;
                case 6:
                    speedBump = 60;
                    Instantiate(obj60, new Vector3(-36.7f, 0.321f, -21.2f), Quaternion.Euler(-90.0f, 0, 180.0f));
                    break;
            }
        }
        else if (bump.CompareTag("FallBump3"))
        {
            switch (rand)
            {
                case 3:
                    speedBump = 30;
                    Instantiate(obj30, new Vector3(-66.42f, 7.68f, 30.91f), Quaternion.Euler(-90.0f, 0, -45.0f));
                    break;
                case 4:
                    speedBump = 40;
                    Instantiate(obj40, new Vector3(-66.42f, 7.68f, 30.91f), Quaternion.Euler(-90.0f, 0, -45.0f));
                    break;
                case 5:
                    speedBump = 50;
                    Instantiate(obj50, new Vector3(-66.42f, 7.68f, 30.91f), Quaternion.Euler(0, -45.0f, 0));
                    break;
                case 6:
                    speedBump = 60;
                    Instantiate(obj60, new Vector3(-66.42f, 7.68f, 30.91f), Quaternion.Euler(-90.0f, 0, -45.0f));
                    break;
            }
        }
        else if (bump.CompareTag("FallBump4"))
        {
            switch (rand)
            {
                case 3:
                    speedBump = 30;
                    Instantiate(obj30, new Vector3(-36.01f, 18.905f, 55.25f), Quaternion.Euler(-90.0f, 0, -45.0f));
                    break;
                case 4:
                    speedBump = 40;
                    Instantiate(obj40, new Vector3(-36.01f, 18.905f, 55.25f), Quaternion.Euler(-90.0f, 0, -45.0f));
                    break;
                case 5:
                    speedBump = 50;
                    Instantiate(obj50, new Vector3(-36.01f, 18.905f, 55.25f), Quaternion.Euler(0, -45.0f, 0));
                    break;
                case 6:
                    speedBump = 60;
                    Instantiate(obj60, new Vector3(-36.01f, 18.905f, 55.25f), Quaternion.Euler(-90.0f, 0, -45.0f));
                    break;
            }
        }
        else if (bump.CompareTag("FallBump5"))
        {
            switch (rand)
            {
                case 3:
                    speedBump = 30;
                    Instantiate(obj30, new Vector3(25.98f, 0.152f, 49.76f), Quaternion.Euler(-90.0f, 0, 0));
                    break;
                case 4:
                    speedBump = 40;
                    Instantiate(obj40, new Vector3(25.98f, 0.152f, 49.76f), Quaternion.Euler(-90.0f, 0, 0));
                    break;
                case 5:
                    speedBump = 50;
                    Instantiate(obj50, new Vector3(25.98f, 0.152f, 49.76f), Quaternion.identity);
                    break;
                case 6:
                    speedBump = 60;
                    Instantiate(obj60, new Vector3(25.98f, 0.152f, 49.76f), Quaternion.Euler(-90.0f, 0, 0));
                    break;
            }
        }
        else if (bump.CompareTag("WinterBump1"))
        {
            switch (rand)
            {
                case 3:
                    speedBump = 30;
                    Instantiate(obj30, new Vector3(56.87f, 11.407f, -7.4f), Quaternion.Euler(-90.0f, 0, -90.0f));
                    break;
                case 4:
                    speedBump = 40;
                    Instantiate(obj40, new Vector3(56.87f, 11.407f, -7.4f), Quaternion.Euler(-90.0f, 0, -90.0f));
                    break;
                case 5:
                    speedBump = 50;
                    Instantiate(obj50, new Vector3(56.87f, 11.407f, -7.4f), Quaternion.Euler(0, -90.0f, 0));
                    break;
                case 6:
                    speedBump = 60;
                    Instantiate(obj60, new Vector3(56.87f, 11.407f, -7.4f), Quaternion.Euler(-90.0f, 0, -90.0f));
                    break;
            }
        }
        else if (bump.CompareTag("WinterBump2"))
        {
            switch (rand)
            {
                case 3:
                    speedBump = 30;
                    Instantiate(obj30, new Vector3(47.97f, 22.655f, 37.81f), Quaternion.Euler(-90.0f, 0, 180.0f));
                    break;
                case 4:
                    speedBump = 40;
                    Instantiate(obj40, new Vector3(47.97f, 22.655f, 37.81f), Quaternion.Euler(-90.0f, 0, 180.0f));
                    break;
                case 5:
                    speedBump = 50;
                    Instantiate(obj50, new Vector3(47.97f, 22.655f, 37.81f), Quaternion.Euler(0, 180.0f, 0));
                    break;
                case 6:
                    speedBump = 60;
                    Instantiate(obj60, new Vector3(47.97f, 22.655f, 37.81f), Quaternion.Euler(-90.0f, 0, 180.0f));
                    break;
            }
        }
        else if (bump.CompareTag("WinterBump3"))
        {
            switch (rand)
            {
                case 3:
                    speedBump = 30;
                    Instantiate(obj30, new Vector3(25.71f, 11.402f, -34.10f), Quaternion.Euler(-90.0f, 0, 180.0f));
                    break;
                case 4:
                    speedBump = 40;
                    Instantiate(obj40, new Vector3(25.71f, 11.402f, -34.10f), Quaternion.Euler(-90.0f, 0, 180.0f));
                    break;
                case 5:
                    speedBump = 50;
                    Instantiate(obj50, new Vector3(25.71f, 11.402f, -34.10f), Quaternion.Euler(0, 180.0f, 0));
                    break;
                case 6:
                    speedBump = 60;
                    Instantiate(obj60, new Vector3(25.71f, 11.402f, -34.10f), Quaternion.Euler(-90.0f, 0, 180.0f));
                    break;
            }
        }
        else if (bump.CompareTag("WinterBump4"))
        {
            switch (rand)
            {
                case 3:
                    speedBump = 30;
                    Instantiate(obj30, new Vector3(-0.05f, 3.94f, -9.9f), Quaternion.Euler(-90.0f, -90.0f, 0));
                    break;
                case 4:
                    speedBump = 40;
                    Instantiate(obj40, new Vector3(-0.05f, 3.94f, -9.9f), Quaternion.Euler(-90.0f, -90.0f, 0));
                    break;
                case 5:
                    speedBump = 50;
                    Instantiate(obj50, new Vector3(-0.05f, 3.94f, -9.9f), Quaternion.Euler(0, -90.0f, 0));
                    break;
                case 6:
                    speedBump = 60;
                    Instantiate(obj60, new Vector3(-0.05f, 3.94f, -9.9f), Quaternion.Euler(-90.0f, -90.0f, 0));
                    break;
            }
        }
        else if (bump.CompareTag("WinterBump5"))
        {
            switch (rand)
            {
                case 3:
                    speedBump = 30;
                    Instantiate(obj30, new Vector3(-34.37f, 11.42f, 25.86f), Quaternion.Euler(-90.0f, 0, 180.0f));
                    break;
                case 4:
                    speedBump = 40;
                    Instantiate(obj40, new Vector3(-34.37f, 11.42f, 25.86f), Quaternion.Euler(-90.0f, 0, 180.0f));
                    break;
                case 5:
                    speedBump = 50;
                    Instantiate(obj50, new Vector3(-34.37f, 11.42f, 25.86f), Quaternion.Euler(0, 180.0f, 0));
                    break;
                case 6:
                    speedBump = 60;
                    Instantiate(obj60, new Vector3(-34.37f, 11.42f, 25.86f), Quaternion.Euler(-90.0f, 0, 180.0f));
                    break;
            }
        }
        else if (bump.CompareTag("WinterBump6"))
        {
            switch (rand)
            {
                case 3:
                    speedBump = 30;
                    Instantiate(obj30, new Vector3(-43.03f, 5.97f, 13.68f), Quaternion.Euler(-57.9f, -90.0f, 270.0f));
                    break;
                case 4:
                    speedBump = 40;
                    Instantiate(obj40, new Vector3(-43.03f, 5.97f, 13.68f), Quaternion.Euler(-57.9f, -90.0f, 270.0f));
                    break;
                case 5:
                    speedBump = 50;
                    Instantiate(obj50, new Vector3(-43.03f, 5.97f, 13.68f), Quaternion.Euler(0, 180.0f, -32.246f));
                    break;
                case 6:
                    speedBump = 60;
                    Instantiate(obj60, new Vector3(-43.03f, 5.97f, 13.68f), Quaternion.Euler(-57.9f, -90.0f, 270.0f));
                    break;
            }
        }
        else if (bump.CompareTag("WinterBump7"))
        {
            switch (rand)
            {
                case 3:
                    speedBump = 30;
                    Instantiate(obj30, new Vector3(-56.49f, 0.152f, -28.59f), Quaternion.Euler(-90.0f, 90.0f, 0));
                    break;
                case 4:
                    speedBump = 40;
                    Instantiate(obj40, new Vector3(-56.49f, 0.152f, -28.59f), Quaternion.Euler(-90.0f, 90.0f, 0));
                    break;
                case 5:
                    speedBump = 50;
                    Instantiate(obj50, new Vector3(-56.49f, 0.152f, -28.59f), Quaternion.Euler(0, 90.0f, 0));
                    break;
                case 6:
                    speedBump = 60;
                    Instantiate(obj60, new Vector3(-56.49f, 0.152f, -28.59f), Quaternion.Euler(-90.0f, 90.0f, 0));
                    break;
            }
        }

        audioSource = GetComponent<AudioSource>();

        audioSource.clip = audioBump;
        audioSource.volume = 1.0f;
        audioSource.mute = true;
    }

    // 충돌 감지
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Bus")) // 충돌한 오브젝트의 태그가 Bus인지 검사
        {
            if (bus.sss > speedBump) // 랜덤으로 지정된 속도 이상일 때
            {
                // 충돌 횟수 증가
                count++;
                Debug.Log(count);
                // 충돌 효과음 내기
                audioSource.mute = false;
                audioSource.Play();
                // 버스 튀어오르는 모션
                rd.AddRelativeForce(new Vector3(1, 0, 0) * 300000);
                rd.AddRelativeForce(new Vector3(0, 1, 0) * 800000);
                rd.AddRelativeForce(new Vector3(0, 0, -1) * 500000);
            }
        }
    }
}