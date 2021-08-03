using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bump : MonoBehaviour
{
    public static int speedBump; // 방지턱 위반 속도 4가지
    private int rand;
    // private Text text;
    Rigidbody rd;

    void Start()
    {
        rand = Random.Range(3, 7); // 변수에 랜덤 저장하여 속도 정함

        switch (rand) {
            case 3:
                speedBump = 30;
                break;
            case 4:
                speedBump = 40;
                break;
            case 5:
                speedBump = 50;
                break;
            case 6:
                speedBump = 60;
                break;
        }
    }

    private void OnCollisionEnter(Collision col){
       rd = col.gameObject.GetComponent<Rigidbody>(); // 충돌한 오브젝트의 리지드바디 받아옴

       if (col.collider.CompareTag("Bus")) // 충돌한 오브젝트의 태그가 Bus인지 검사
       {
            Debug.Log(speedBump);
            if (car.sss > speedBump) // 랜덤으로 지정된 속도 이상일 때
           {
                // 버스 튀어오르는 모션
                rd.AddRelativeForce(new Vector3(1, 0, 0) * 200000);
                rd.AddRelativeForce(new Vector3(0, 1, 0) * 800000);
                rd.AddRelativeForce(new Vector3(0, 0, -1) * 500000);
           }
       }
    }

}
