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

    void Start()
    {
        face = GetComponent<Image>();
        audioSource = GetComponent<AudioSource>();
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
                audioCount++;
            }
            face.sprite = Resources.Load<Sprite>("UI/기록_보통");
        }
        else
        {
            if (audioCount <= 1)
            {
                audioSource.Play();
                audioCount++;
            }
            face.sprite = Resources.Load<Sprite>("UI/기록_나쁨");
        }

    }
}
