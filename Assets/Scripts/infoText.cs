using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class infoText : MonoBehaviour
{
    private TextMeshProUGUI txt;

    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<TextMeshProUGUI> (); 
        switch (toLoading.ld)
        {
            case 0:
                txt.text = LocalizationManager.instance.GetLocalizedValue("txt_loading1");
                break; 
            case 1:
                txt.text = LocalizationManager.instance.GetLocalizedValue("txt_loading2");
                break;
            case 2:
                txt.text = LocalizationManager.instance.GetLocalizedValue("txt_loading3");
                break;
            case 3:
                txt.text = LocalizationManager.instance.GetLocalizedValue("txt_loading4");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
