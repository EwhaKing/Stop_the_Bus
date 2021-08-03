using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class car : MonoBehaviour{

    public Animation[] tires = new Animation[4]; //바퀴가 돌아가는 걸 표현하기위한 메쉬
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
        //for (int i=0;i<4;i++)  tires[i].Rotate(Vector3.right * 0.5f * -speed);

        if (Input.GetKeyDown(KeyCode.A) && speed != 0){
            for (int i=0;i<4;i++)  tires[i].Play("wheel_left");
        }
        else if (Input.GetKeyDown(KeyCode.D) && speed != 0){
            for (int i=0;i<4;i++)  tires[i].Play("wheel_right");
        }


        if(Input.GetKey(KeyCode.A) && speed != 0)
        {
            transform.Rotate(Vector3.up * 0.1f * -speed);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * 0.1f * speed);           
        }


        sss = (int)(speed * 10);
        speedT.text = sss.ToString();

        //1초 내에 속도변화가 일어나지 않으면 0.1초에 1씩 줄어듦
        if (speed != 0 && Time.time - timecheck >= 0.1) {
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
        /*
        else if(col.collider.CompareTag("curve90")){
            cameraMove.rotat = 90;
        }
        else if(col.collider.CompareTag("curve180")){
            cameraMove.rotat = 180;
        }*/
    }

    void OnCollisionExit(Collision col){
        
        if (col.collider.CompareTag("gravel")){
            accel = 0.01f;
        }
        
    }

}