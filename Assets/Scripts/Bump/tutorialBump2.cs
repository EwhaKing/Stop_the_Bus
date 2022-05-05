using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialBump2 : MonoBehaviour
{
    public AudioClip audioBump;

    AudioSource audioSource;
    public Rigidbody rd;

    void Start()
    {
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
            if (bus.speed > tutorialBump1.speedBump) // 랜덤으로 지정된 속도 이상일 때
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
