using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinterFace : MonoBehaviour
{
    int comfort;
    private Image face;

    void Start()
    {
        face = GetComponent<Image>();
    }

    void Update()
    {
        comfort = WinterComfort.GetComfort();

        if (comfort <= 100 && comfort >= 80)
            face.sprite = Resources.Load<Sprite>("UI/기록_좋음");
        else if (comfort < 80 && comfort >= 40)
            face.sprite = Resources.Load<Sprite>("UI/기록_보통");
        else
            face.sprite = Resources.Load<Sprite>("UI/기록_나쁨");
    }
}
