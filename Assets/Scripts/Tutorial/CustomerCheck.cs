using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerCheck : MonoBehaviour
{
    TutorialCustomer obj;
    public static int SumOfCus;     //손님 합계
    private int count;              //손님 수 한 번만 더하기
    public GameObject newSign;
    public GameObject removeText;
    public GameObject newText;
    public GameObject busObject;
    public AudioSource outEff;

    void Start()
    {
        obj = GameObject.Find("BusStopSign").GetComponent<TutorialCustomer>();
        SumOfCus = 0;
        count = 0;
    }

    
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Bus")
        {
            CustomerChecking();
        }
    }

    void CustomerChecking(){
        //손님 들어있을 경우
        if (!obj.Taken() && count == 0) {
            newSign.active = true; //다음 빨간선 보이게
            Destroy(removeText); //현재 설명텍스트 사라지게
            newText.active = true;}//다음 설명텍스트 보이게 

        //손님 안들어있을 경우
        else{
            busObject.transform.position = new Vector3(22.7f, 0.6f, -9.23f);//위치로 리스폰
            outEff.Play();

        }
    }
}