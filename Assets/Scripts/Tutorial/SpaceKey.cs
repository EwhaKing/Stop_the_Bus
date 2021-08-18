using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceKey : MonoBehaviour
{
    public Image oldImage;
    public Sprite TestSprite;
    public Sprite OriginSprite;

    void Update()
    {   
        if(Input.GetKey(KeyCode.Space)){
            ChangeImg();
                }
        if(Input.GetKeyUp(KeyCode.Space)){
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
