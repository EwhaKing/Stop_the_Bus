using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FallEndSign : MonoBehaviour
{
    public GameObject cursorMap;
    public GameObject bubble;
    public Texture2D defaltCursor;
    
    public GameObject result;  //결과 팝업창
    public Timer timer;        //시간 가져오기
    public TextMeshProUGUI NumOfCus;      //팝업창 손님 수
    public TextMeshProUGUI Time;          //팝업창 시간
    public Image Face;         //팝업창 만족도 이미지
    public GameObject clickPanel;

    int comfortNum;     //만족도 1(좋음), 0(보통), -1(나쁨)
    int count;

    string wheel;
    bool wheel1, wheel2, wheel3, wheel4;

    void Start()
    {
        count = 0;
        wheel1 = false;
        wheel2 = false;
        wheel3 = false;
        wheel4 = false;
    }

    void OnTriggerStay(Collider coll)
    {
        wheel = coll.gameObject.name;
        if (wheel == "BUS_wheelLB")
            wheel1 = true;
        else if (wheel == "BUS_wheelLF")
            wheel2 = true;
        else if (wheel == "BUS_wheelRB")
            wheel3 = true;
        else if (wheel == "BUS_wheelRF")
            wheel4 = true;

        if (wheel1 && wheel2 && wheel3 && wheel4 && bus.sss == 0)
        {
            NumOfCus.text = FallTotal.SumOfCus.ToString();      //계절 스크립트별
            Timer.timerPause = true;        //시간 정지
            Time.text = timer.GetTime();    //시간 팝업창
            SetResultFace();                //만족도 얼굴 
            FallComfort.end = true;         //엔딩 만족도 안 줄어들게
            //bus.sss = 0; <-- 이렇게 해야 하나? 현재 bus의 breaks 변수는 private임
            result.SetActive(true);         //엔딩 팝업창 나타남
            clickPanel.SetActive(true);    

            cursorMap.SetActive(false);         // 커서 영역, 손님 수 말풍선 가리기
            bubble.SetActive(false); 
            Cursor.SetCursor (defaltCursor, Vector2.zero, CursorMode.Auto);
            
            //기록 업데이트
            BestScore.UpdateFall(comfortNum, timer.GetMin(), timer.GetSec(), FallTotal.SumOfCus);
        }
    }

    void SetResultFace()
    {
        int comfort = FallComfort.comfort;

        if (count == 0)
        {
            if (comfort >= 80)
            {
                Face.sprite = Resources.Load<Sprite>("UI/Record_good");
                comfortNum = 1;
            }
            else if (comfort >= 40)
            {
                Face.sprite = Resources.Load<Sprite>("UI/Record_normal");
                comfortNum = 0;
            }
            else
            {
                Face.sprite = Resources.Load<Sprite>("UI/Record_bad");
                comfortNum = -1;
            }
            count++;
        }
    }
}
