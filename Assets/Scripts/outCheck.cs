using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class outCheck : MonoBehaviour{
    public GameObject popup;
    public GameObject panel;
    public AudioSource outEff;
    public GameObject cursorMap;
    public GameObject bubble; // 손님 수 말풍선
    public Texture2D defaltCursor;
    private bool flag;

    void Start(){
        flag = true;
    }
    void Update(){
        if (bus.isOut){
            bus.speed = 0;
            Cursor.SetCursor (defaltCursor, Vector2.zero, CursorMode.Auto);

            //타이머 정지
            if (flag){
                flag = false;
                outEff.Play();
            }
            popup.SetActive(true);
            panel.SetActive(true);

            cursorMap.SetActive(false);
            bubble.SetActive(false);

        }
    }

}