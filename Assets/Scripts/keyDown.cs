using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyDown : MonoBehaviour
{
    public Image TestImage;
    public Sprite TestSprite;

    // Update is called once per frames
    void Update()
    {   
        if(Input.GetKey(KeyCode.Space)){
            TestImage.sprite = TestSprite;
                }
    }
}
