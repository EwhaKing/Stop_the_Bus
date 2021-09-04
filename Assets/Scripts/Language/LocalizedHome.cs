using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// 텍스트 오브젝트마다 넣어주는거
public class LocalizedHome : MonoBehaviour
{
    public string key;
    TextMeshProUGUI t;

    // Start is called before the first frame update
    void Start()
    {
        t = gameObject.GetComponent<TextMeshProUGUI>();
        

    }

    void Update(){
        t.text = LocalizationManager.instance.GetLocalizedValue(key);
    }

}