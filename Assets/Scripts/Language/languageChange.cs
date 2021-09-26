using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class languageChange : MonoBehaviour {

    private LocalizationManager lang;

    void Start(){
        lang = GameObject.Find("btnaudio").GetComponent<LocalizationManager>();
    }

    public void ChangeLang(){
        
        if (PlayerPrefs.GetString("lang") == "localizedText_kr") {
            Debug.Log("지금설정 : "+PlayerPrefs.GetString("lang"));
            lang.LoadLocalizedText("localizedText_en");
            Debug.Log("영어~~~");
        }
        else{
            Debug.Log("지금설정 : "+PlayerPrefs.GetString("lang"));
            lang.LoadLocalizedText("localizedText_kr");
            
            Debug.Log("한국어~~~");
        }
    }
}