using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mouse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float AlphaThreshold = 0.1f; // 이미지 모양대로 버튼을 인식하는 스크립트

    private Vector3 mousePos;
    public static bool isHovering = false; // 마우스오버 여부 
    public static bool isSpeeding = false; // 마우스가 회전 중인지
    
    private float oldX;
    private float oldY;
    private float curX;
    private float curY;
    public static float crossP; // 외적값
    private float originX;
    private float originY;

    //마우스 커서
    public Texture2D defaltCursor;
    public Texture2D driveCursor;
    private Vector2 pointer; //커서 좌표


    void Update()
    {
        //마우스오버시 수행내용
        if (isHovering)
        {
            // 화면 모서리를 원점으로 하는 마우스 포지션 좌표를 화면 중심을 원점으로 하는 좌표로 바꿔서 얻어옴
            oldX = mousePos.x - originX;
            oldY = mousePos.y - originY;

            mousePos = Input.mousePosition;

            curX = mousePos.x - originX;
            curY = mousePos.y - originY;

            crossP = curY*oldX - curX*oldY; // CCW, CW 판별을 위한 벡터 외적값. 프레임단위 마우스 이동거리 벡터
            if (crossP != 0) isSpeeding = true; //Bus.changeSpeed();
            
        }

        
    }

    public void OnPointerEnter(PointerEventData eventData) // 도넛모양의 버튼 위에서 마우스 회전 속도를 감지
    {
        // 마우스 오버
        Cursor.SetCursor (driveCursor, pointer, CursorMode.Auto);
        mousePos = Input.mousePosition; // 이전 마우스 좌표는 현재좌표로 초기화
        isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // 마우스오버 영역 벗어남
        Cursor.SetCursor (defaltCursor, Vector2.zero, CursorMode.Auto);
        isHovering = false;
        isSpeeding = false;

    }

    void Start()
    {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = AlphaThreshold; // 이미지 모양대로 버튼 인식하는 스크립트
        
        originX = Screen.width / 2;
        originY = Screen.height / 2;
        pointer.x = driveCursor.width / 2;
        pointer.y = driveCursor.height / 2;

    }

}