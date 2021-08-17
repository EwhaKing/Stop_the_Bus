using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

    //마우스 커서
    public Texture2D defaltCursor;
    public Texture2D driveCursor;
    private Vector2 pointer; //커서 좌표

    
    // Update is called once per frame
    void Awake(){
    }
    void Update()
    {
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
        Cursor.SetCursor (driveCursor, pointer, CursorMode.Auto);
        mousePos = Input.mousePosition; //이전 마우스 좌표는 현재좌표로 초기화
        m = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // 마우스오버 영역 벗어남
        Cursor.SetCursor (defaltCursor, Vector2.zero, CursorMode.Auto);
        m = false;
        speedChange = false;

    }

    void Start()
    {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = AlphaThreshold; //이미지 모양대로 버튼 인식하는 스크립트
        
        originX = Screen.width / 2;
        originY = Screen.height / 2;
        pointer.x = driveCursor.width / 2;
        pointer.y = driveCursor.height / 2;

    }

}