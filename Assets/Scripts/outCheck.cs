using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class outCheck : MonoBehaviour{
    public GameObject popup;
    public GameObject panel;
    public AudioSource outEff;
    private bool flag;

    void Start(){
        flag = true;
    }
    void Update(){
        if (bus.isOut){
            bus.speed = 0;
            //타이머 정지
            if (flag){
                Debug.Log("!!");
                flag = false;
                outEff.Play();
            }
            popup.SetActive(true);
            panel.SetActive(true);

        }
    }

}