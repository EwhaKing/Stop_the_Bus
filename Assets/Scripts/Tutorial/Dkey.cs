using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dkey : MonoBehaviour
{
    public Image oldImage;
    public Sprite TestSprite;
    public Sprite OriginSprite;

    void Update()
    {
        if(Input.GetKey(KeyCode.D)){
            ChangeImg();
                }
        if(Input.GetKeyUp(KeyCode.D)){
            ChangeOrigin();
        }
    }
    public void ChangeImg(){
        oldImage.sprite = TestSprite;
    }

    public void ChangeOrigin(){
        oldImage.sprite = OriginSprite;
    }
}
