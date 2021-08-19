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
                txt.text = "한 자리에 너무 오래 머무르면 승객들이 불만을 표시합니다.";
                break;
            case 1:
                txt.text = "물웅덩이에서는 원하지 않는 방향으로 미끄러질 수 있습니다.";
                break;
            case 2:
                txt.text = "아스팔트 포장도로는 길이 매끄러우니 속도 조절에 유의하세요.";
                break;
            case 3:
                txt.text = "푸른 빙판 위에서는 바퀴가 얼어붙을 수 있으니 조심하세요.";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
