using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class loadingImage : MonoBehaviour
{
    private Image bg;

    // Start is called before the first frame update
    void Start()
    {
        bg = GetComponent<Image>();

        switch (toLoading.ld)
        {
            case 0:
                bg.sprite = Resources.Load<Sprite>("UI/로딩_봄가을");
                break;
            case 1:
                bg.sprite = Resources.Load<Sprite>("UI/로딩_여름겨울");
                break;
            case 2:
                bg.sprite = Resources.Load<Sprite>("UI/로딩_봄가을");
                break;
            case 3:
                bg.sprite = Resources.Load<Sprite>("UI/로딩_여름겨울");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
