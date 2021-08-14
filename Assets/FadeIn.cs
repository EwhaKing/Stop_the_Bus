using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    Fade Panel;

    void Start()
    {
        Panel = GameObject.Find("Canvas").transform.Find("FadeIn").GetComponent<Fade>();

    }

    void Update()
    {
        if(Fade.change)
        {
            Panel.gameObject.SetActive(true);
            Panel.ActiveFadeIn();
        }
        
        if (Panel.Panel.color.a == 0f)
        {
            Fade.change = false;
            Panel.gameObject.SetActive(false);
        }
    }
}
