using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class muteVolume : MonoBehaviour
{
    // Start is called before the first frame update
    private Image img;
    void Start()
    {
        img = gameObject.GetComponent<Image>();
        if (data.mute){
            img.sprite = Resources.Load<Sprite>("UI/음향 off");
        }
        else{
            img.sprite = Resources.Load<Sprite>("UI/음향 on");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
