using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpringFace : MonoBehaviour
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
        comfort = SpringComfort.GetComfort();

        if (comfort >= 80)
            face.sprite = Resources.Load<Sprite>("UI/Record_good");
        else if (comfort >= 40)
        {
            if (audioCount == 0)
            {
                audioSource.Play();
                ani.Play("face_change");
                audioCount++;
            }
            face.sprite = Resources.Load<Sprite>("UI/Record_normal");
        }
        else
        {
            if (audioCount <= 1)
            {
                audioSource.Play();
                ani.Play("face_change");
                audioCount++;
            }
            face.sprite = Resources.Load<Sprite>("UI/Record_bad");
        }

    }
}
