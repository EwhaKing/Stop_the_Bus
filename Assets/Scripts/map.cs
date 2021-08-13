using UnityEngine; 
using System.Collections; 
using System.Collections.Generic;


// 새로운 자동차 생성 스크립트
public class map : MonoBehaviour { 


    // Update is called once per frame 
    void OnTriggerEnter(Collider col) { 
        Debug.Log("게임오버22222222");
        if (col.CompareTag("Bus")){
            print("게임오버22222222");
            // 게임오버 엔딩창
        }   
    } 

}
