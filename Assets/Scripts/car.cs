using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour{

    public WheelCollider[] wheels = new WheelCollider[4]; //휠 콜라이더를 받아온다.
    public Transform[] tires = new Transform[4]; //바퀴가 돌아가는 걸 표현하기위한 메쉬를 받아온다.

    public float maxF = 50.0f; //자동차바퀴를 돌리는 힘
    public float power= 3000.0f; //자동차를 밀어주는 힘(바퀴만으로는 너무 느리다..)
    public float rot = 45;

    Rigidbody rb;

    void Start()
    {/*
        rb = GetComponent<Rigidbody>(); //리지드바디를 받아온다.

        for (int i = 0; i < 4; i++)
        {
            wheels[i].steerAngle = 0; //만약 바퀴와 휠콜라이더의 방향이 교차한다면 90으로 설정해주자.
            wheels[i].ConfigureVehicleSubsteps(5, 12, 13);
        }
        rb.centerOfMass = new Vector3(0, 0, 0); //무게중심을 가운데로 맞춰서 안정적으로 주행하도록 한다.*/
    }

    private void Update()
    {
        //UpdateMeshesPostion(); 
        
        //float a = Input.GetAxis("Vertical");
        //rb.AddForce(transform.rotation * new Vector3(a * power, 0, 0)); //뒤에서 밀어준다.
/*
        for (int i = 0; i < 4; i++)
        {
            wheels[i].motorTorque = mouse.velocity; //바퀴를 돌린다.
            print(mouse.velocity);
        }
        float steer = rot * Input.GetAxis("Horizontal");

        for (int i = 0; i < 2; i++) //앞바퀴만 회전한다.
        {
            wheels[i].steerAngle = steer; //여기도 바퀴와 콜라이더가 직각인사람은 + 90을 해줘야한다.
        }*/
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * 0.01f * mouse.velocity);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * -0.01f * mouse.velocity);
        }

    }

/*
    void UpdateMeshesPostion()
    {
        for (int i = 0; i < 4; i++)
        {
            Quaternion quat;
            Vector3 pos;
            wheels[i].GetWorldPose(out pos, out quat);
            tires[i].position = pos;
            tires[i].rotation = quat;
        }
    }*/
}