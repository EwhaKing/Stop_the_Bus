using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tutotext : MonoBehaviour
{
    TextMeshProUGUI text; 
    
    void Start (){ 
        text = GetComponent<TextMeshProUGUI> (); 
        StartCoroutine (FadeTextToFullAlpha()); } 

     public IEnumerator FadeTextToFullAlpha() // 알파값 0에서 1로 전환
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / 1.0f));
            yield return null;
        }
        StartCoroutine(FadeTextToZero());
    }

    public IEnumerator FadeTextToZero()  // 알파값 1에서 0으로 전환
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / 3.5f));
            yield return null;
        }
        StartCoroutine(FadeTextToFullAlpha());
    }
}