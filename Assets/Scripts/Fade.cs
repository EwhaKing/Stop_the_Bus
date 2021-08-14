using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image Panel;
    float time = 0f;
    float F_time = 2f;
    public static bool change;

    void Awake()
    {
        change = false;    
    }

    public void ActiveFadeOut()
    {
        StartCoroutine(FadeOut());
    }

    public void ActiveFadeIn()
    {
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeOut()
    {
        Color alpha = Panel.color;
        
        while(alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.SmoothStep(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }

        yield return null;
    }

    public IEnumerator FadeIn()
    {
        Color alpha = Panel.color;

        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.SmoothStep(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }

        yield return null;
    }
}
