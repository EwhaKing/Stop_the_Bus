using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class infoText : MonoBehaviour
{
    private Text txt;

    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();

        switch (toLoading.ld)
        {
            case 0:
                txt.text = "한 자리에 너무 오래 머무르면 손님들이 승차감에 불만족합니다.";
                break;
            case 1:
                txt.text = "물 웅덩이에선 원하지 않은 방향으로 가게 됩니다.";
                break;
            case 2:
                txt.text = "자갈길에선 길이 오돌토돌하니 속도 조절에 주의하세요.";
                break;
            case 3:
                txt.text = "푸른 빙판 위에선 원하는 방향으로 가지 못합니다.";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
