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
            lang.LoadLocalizedText("localizedText_en");
        }
        else{
            lang.LoadLocalizedText("localizedText_kr");
        }
    }
}