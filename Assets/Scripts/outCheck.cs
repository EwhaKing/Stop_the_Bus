using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class outCheck : MonoBehaviour{
    public GameObject popup;
    public GameObject panel;


    void Update(){
        if (bus.isOut){
            bus.speed = 0;
            //타이머 정지
            popup.SetActive(true);
            panel.SetActive(true);
            bus.isOut = false;
        }
    }

}