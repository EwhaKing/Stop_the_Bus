using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour{

    public Transform[] tires = new Transform[4]; //바퀴가 돌아가는 걸 표현하기위한 메쉬

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //리지드바디를 받아온다.
        rb.centerOfMass = new Vector3(0, 0, 0); //무게중심을 가운데로 맞춰서 안정적으로 주행하도록 한다.*/
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * 0.01f * -mouse.speed);

        if(Input.GetKey(KeyCode.A) && mouse.speed != 0)
        {
            transform.Rotate(Vector3.up * 0.1f * -mouse.speed);
            //for (int i=0;i<4;i++)  tires[i].Rotate(Vector3.up * 0.1f * -mouse.speed);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * 0.1f * mouse.speed);           
            //for (int i=0;i<4;i++)  tires[i].Rotate(Vector3.up * 0.1f * mouse.speed);
        }

    }


}