using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class mouse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public WheelCollider el1;
    public WheelCollider el2;
    public WheelCollider el3;
    public WheelCollider el4;

    private Vector3 mousePos;
    private bool m = false; //마우스오버 여부 
    
    private float oldX;
    private float oldY;
    private float curX;
    private float curY;
    public static float velocity;

    // Update is called once per frame
    void Update()
    {
        //1초 내에 변화가 일어나지 않으면 줄어듦

        if (m)
        {
            oldX = mousePos.x;
            oldY = mousePos.y;

            mousePos = Camera.main.ScreenToWorldPoint(
            new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            -Camera.main.transform.position.z)
            );

            curX = mousePos.x;
            curY = mousePos.y;

            /*
            var v = Math.Pow(curX - oldX, 2) + Math.Pow(curY - oldY, 2);
            vel = (float)Math.Sqrt(v)/(float)Time.deltaTime; //속도
            */

            //if (oldX + curX < 0.1 && oldX + curX > -0.1) changeSpeed(1,0); //마우스 가로이동 속도변화
            //if (oldY + curY < 0.1 && oldY + curY > -0.1) changeSpeed(0,1); //마우스 세로이동 속도변화
            changeSpeed(1,0);
            el1.motorTorque = -velocity;
            el2.motorTorque = -velocity;
            el3.motorTorque = -velocity;
            el4.motorTorque = -velocity;
            
        }

        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        m = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m = false;
    }

    public float AlphaThreshold = 0.1f; //이미지 모양대로 버튼 인식하는 스크립트

    void Start()
    {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = AlphaThreshold; //이미지 모양대로 버튼 인식하는 스크립트
        velocity = 0;
    }

    void changeSpeed(int x, int y){

        if (curY*oldX - curX*oldY > 0) {
            velocity += 0.1f;
            print("반시계"+velocity);
        }
        else if (curY*oldX - curX*oldY < 0){
            velocity -= 0.1f;
            print("시계"+velocity);
        }
/*
        print("들어옴");
        if (x==1){ //마우스 가로이동 속도변화
            float dX = curX - oldX;
            // x가 +에서 -로 변할때
            if (dX < 0 && curY > 0) {
                velocity += 10;
                print("반시계"+velocity);
            }
            else if (dX < 0 && curY < 0) {
                velocity -= 10;
                print("시계"+velocity);
            }
            //x가 -에서 +로 변할때
            else if (dX > 0 && curY > 0) {
                velocity -= 10;
                print("반시계"+velocity);
            }
            else if (dX > 0 && curY < 0) {
                velocity += 10;
                print("시계"+velocity);
            }
            //print(mousePos.x+"x "+velocity);
        }

        if (y==1){ //마우스 세로이동 속도변화
            float dY = curY - oldY;
            // y가 +에서 -로 변할때
            if (dY < 0 && curX > 0) velocity -= 10;
            else if (dY < 0 && curX < 0) velocity += 10;
            // y가 -에서 +로 변할때
            else if (dY > 0 && curX > 0) velocity += 10;
            else if (dY > 0 && curX < 0) velocity -= 10;
            print(velocity);
        }*/
    }
}
