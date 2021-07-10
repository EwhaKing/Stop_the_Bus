using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class mouse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public WheelCollider eel;

    private Vector3 mousePos;
    private bool m = false; //마우스오버 여부 
    
    private float oldX;
    private float oldY;
    private float curX;
    private float curY;
    private float velocity;

    // Update is called once per frame
    void Update()
    {
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

            var v = Math.Pow(curX - oldX, 2) + Math.Pow(curY - oldY, 2);
            velocity = (float)Math.Sqrt(v)/(float)Time.deltaTime; //속도
            print(velocity);
            eel.motorTorque = velocity;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        m = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m = false;
        print("Exit");
    }

    public float AlphaThreshold = 0.1f; //이미지 모양대로 버튼 인식하는 스크립트

    void Start()
    {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = AlphaThreshold; //이미지 모양대로 버튼 인식하는 스크립트
    }
}
