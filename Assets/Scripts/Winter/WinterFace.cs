using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinterFace : MonoBehaviour
{
    int comfort;
    int audioCount;
    private Image face;
    AudioSource audioSource;
    Animation ani;

    void Start()
    {
        face = GetComponent<Image>();
        audioSource = GetComponent<AudioSource>();
        ani = GetComponent<Animation>();
        audioCount = 0;
    }

    void Update()
    {
        comfort = WinterComfort.GetComfort();

        if (comfort >= 80)
            face.sprite = Resources.Load<Sprite>("UI/기록_좋음");
        else if (comfort >= 40)
        {
            if (audioCount == 0)
            {
                audioSource.Play();
                ani.Play("face_change");
                audioCount++;
            }
            face.sprite = Resources.Load<Sprite>("UI/기록_보통");
        }
        else
        {
            if (audioCount <= 1)
            {
                audioSource.Play();
                ani.Play("face_change");
                audioCount++;
            }
            face.sprite = Resources.Load<Sprite>("UI/기록_나쁨");
        }

    }
}
