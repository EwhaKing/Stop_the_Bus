using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class mouse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float AlphaThreshold = 0.1f; //이미지 모양대로 버튼 인식하는 스크립트

    public Rigidbody rb;
    private Vector3 mousePos;
    public static bool m = false; //마우스오버 여부 
    public static bool speedChange = false;
    
    private float oldX;
    private float oldY;
    private float curX;
    private float curY;
    public static float crossP; // 외적값
    private float originX;
    private float originY;
    /*
    private float velocity;
    public float accel; //0.01씩 증가가 기본, 유니티 씬에서 받아오는 값 (맵마다 다른 값)
    public static float speed;
    public static int sss; // 스크린에 비춰지는 속도값

    private float timecheck; //속도 떨어뜨릴때 타임체크

    private float originX;
    private float originY;

    public TextMeshProUGUI speedT; // 스크린에 속도값 보여주는 텍스트
*/
    // Update is called once per frame
    void Awake(){
        Screen.SetResolution(1320, 1030, false);
    }
    void Update()
    {
        /*
        sss = (int)(speed * 10);
        speedT.text = sss.ToString();

        //1초 내에 속도변화가 일어나지 않으면 0.1초에 1씩 줄어듦
        if (speed != 0 && Time.time - timecheck >= 0.1) {
            timecheck = Time.time;
            if (speed < 0.1f && speed > -0.1f) speed = 0;
            else if (speed > 0) speed-=0.1f;
            else if (speed < 0) speed+=0.1f;
        }*/

        //마우스오버시 수행내용
        if (m)
        {
            oldX = mousePos.x - originX;
            oldY = mousePos.y - originY;

            mousePos = Input.mousePosition;

            curX = mousePos.x - originX;
            curY = mousePos.y - originY;

            crossP = curY*oldX - curX*oldY; // CCW, CW 판별을 위한 벡터 외적값. 프레임단위 마우스 이동거리 벡터
            if (crossP != 0) speedChange = true; //changeSpeed();
            
        }

        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // 마우스 오버
        mousePos = Input.mousePosition; //이전 마우스 좌표는 현재좌표로 초기화
        m = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // 마우스오버 영역 벗어남
        m = false;
        speedChange = false;
        //velocity = 0; //누적되던 속도변수 초기화

    }

    void Start()
    {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = AlphaThreshold; //이미지 모양대로 버튼 인식하는 스크립트
        
        //변수 초기화
        //velocity = 0;
        //speed = 0;
        originX = Screen.width / 2;
        originY = Screen.height / 2;
    }
/*
    void changeSpeed(){ //속도변화

        if (crossP > 0) {
            velocity += 0.01f * crossP;
        }
        else if (crossP < 0){
            velocity += 0.01f * crossP;
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
    }*/
}
