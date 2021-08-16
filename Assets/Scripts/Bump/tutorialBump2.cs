using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialBump2 : MonoBehaviour
{
    public static int speedBump; // 방지턱 위반 속도 4가지
    public AudioClip audioBump;

    AudioSource audioSource;
    public Rigidbody rd;

    void Start()
    {

        // tutorialBump1과 같은 속도 지정
        switch (tutorialBump1.speedBump)
        {
            case 30:
                speedBump = 30;
                break;
            case 40:
                speedBump = 40;
                break;
            case 50:
                speedBump = 50;
                break;
            case 60:
                speedBump = 60;
                break;
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
                // 충돌 효과음 내기
                audioSource.mute = false;
                audioSource.Play();
                // 버스 튀어오르는 모션
                rd.AddRelativeForce(new Vector3(1, 0, 0) * 200000);
                rd.AddRelativeForce(new Vector3(0, 1, 0) * 800000);
                rd.AddRelativeForce(new Vector3(0, 0, -1) * 500000);
            }
        }
    }
}
