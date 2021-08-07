using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class car : MonoBehaviour{

    public WheelCollider[] colls = new WheelCollider[4]; //바퀴가 돌아가는 걸 표현하기위한 메쉬
    public Transform[] tires = new Transform[4];
    Rigidbody rb;
    
    private float velocity;
    public float accel; //0.01씩 증가가 기본, 유니티 씬에서 받아오는 값 (맵마다 다른 값)
    public static float speed;
    public static int sss; // 스크린에 비춰지는 속도값

    private float timecheck; //속도 떨어뜨릴때 타임체크

    public TextMeshProUGUI speedT;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //리지드바디를 받아온다.
        rb.centerOfMass = new Vector3(0, 0, 0); //무게중심을 가운데로 맞춰서 안정적으로 주행하도록 한다.*/
        velocity = 0;
        speed = 0;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * 0.01f * -speed);

        //자동차 바퀴 회전
        for (int i=0;i<4;i++)  { 
            tires[i].Rotate(Vector3.right * -speed);
            if (i%2==1 && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))){
                colls[i].steerAngle = 5 * Input.GetAxis("Horizontal") * Math.Abs(speed);
                Vector3 position;
                Quaternion rotation;
                
                Vector3 rot;
                colls[i].GetWorldPose(out position, out rotation);
                //rot = tires[i].eulerAngles + rotation.eulerAngles;
                tires[i].rotation = rotation;
            }
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)){
            transform.Rotate(Vector3.up * 0.05f * Input.GetAxis("Horizontal") * Math.Abs(speed));
        }
        /*
        if(Input.GetKey(KeyCode.A) && speed != 0)
        {
            transform.Rotate(Vector3.up * 0.1f * -speed);
            for (int i=0;i<4;i++)  { 
                if (i%2==1){
                    colls[i].steerAngle = 5 * Input.GetAxis("Horizontal") * Math.Abs(speed);
                    Vector3 position;
                    Quaternion rotation;
                    colls[i].GetWorldPose(out position, out rotation);
                    tires[i].rotation = rotation;
                }
            }
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * 0.1f * speed);
            for (int i=0;i<4;i++)  { 
                if (i%2==1){
                    colls[i].steerAngle = 5 * Input.GetAxis("Horizontal") * Math.Abs(speed);
                    Vector3 position;
                    Quaternion rotation;
                    colls[i].GetWorldPose(out position, out rotation);
                    tires[i].rotation = rotation;
                }
            }           
        }*/


        sss = (int)(speed * 10);
        speedT.text = sss.ToString();

        //1초 내에 속도변화가 일어나지 않으면 0.1초에 1씩 줄어듦 //귀찮아서 2초로 늘림
        if (speed != 0 && Time.time - timecheck >= 0.2) {
            timecheck = Time.time;
            if (speed < 0.1f && speed > -0.1f) speed = 0;
            else if (speed > 0) speed-=0.1f;
            else if (speed < 0) speed+=0.1f;
        }

        //마우스오버시 수행내용
        if (mouse.speedChange)
        {
            changeSpeed();
        }
        else {
            velocity = 0;
        }

    }

    void changeSpeed(){ //속도변화

        if (mouse.crossP > 0) {
            velocity += 0.01f * mouse.crossP;
        }
        else if (mouse.crossP < 0){
            velocity += 0.01f * mouse.crossP;
        }

        if (velocity >= 1) {
            speed += accel;
            velocity = 0;
            timecheck = Time.time;
        }
        else if (velocity <= -1){
            speed -= accel;
            velocity = 0;
            timecheck = Time.time;
        }
    }


    void OnCollisionEnter(Collision col){
        if (col.collider.CompareTag("gravel")){
            accel = 0.015f;
        }
    }

    void OnCollisionExit(Collision col){
        
        if (col.collider.CompareTag("gravel")){
            accel = 0.01f;
        }
        
    }

}