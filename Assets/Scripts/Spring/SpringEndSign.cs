using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpringEndSign : MonoBehaviour
{
    public GameObject cursorMap;
    public GameObject bubble;
    public Texture2D defaltCursor;
    
    public GameObject result;  //��� �˾�â
    public Timer timer;        //�ð� ��������
    public TextMeshProUGUI NumOfCus;      //�˾�â �մ� ��
    public TextMeshProUGUI Time;          //�˾�â �ð�
    public Image Face;         //�˾�â ������ �̹���
    public GameObject clickPanel;

    int comfortNum;     //������ 1(����), 0(����), -1(����)
    int count;          //

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
            NumOfCus.text = SpringTotal.SumOfCus.ToString();      //���� ��ũ��Ʈ��
            Timer.timerPause = true;         //�ð� ����
            Time.text = timer.GetTime();    //�ð� �˾�â
            SetResultFace();
            SpringComfort.end = true;
            result.SetActive(true);     //���� �˾�â ��Ÿ��
            clickPanel.SetActive(true);

            cursorMap.SetActive(false);         // 커서 영역, 손님 수 말풍선 가리기
            bubble.SetActive(false); 
            Cursor.SetCursor (defaltCursor, Vector2.zero, CursorMode.Auto);

            //��� ������Ʈ
            BestScore.UpdateSpring(comfortNum, timer.GetMin(), timer.GetSec(), SpringTotal.SumOfCus);
        }
    }

    void SetResultFace()
    {
        int comfort = SpringComfort.comfort;
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
