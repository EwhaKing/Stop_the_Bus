using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    float _Sec;
    int _Min;
    [SerializeField]
    TextMeshProUGUI _TimerText;

    public static bool timerPause;    //일시정지 버튼 누를 때 사용

    private void Start()
    {
        timerPause = false; //일시정지 버튼X. 시간이 지나도록 설정
    }

    private void Update()
    {
        realTimer();
    }

    void realTimer()
    {
        if (Goal.goal == false)
        {
            if (!timerPause)    //일시정지 버튼을 안 눌렀다면
            {
                _Sec += Time.deltaTime;
                if ((int)_Sec > 59)
                {
                    _Sec = 0;
                    _Min++;
                }
            }
            _TimerText.text = string.Format("{0:D2}:{1:D2}", _Min, (int)_Sec);
        }
    }

    public void TimerPause()
    {
        Time.timeScale = 0.0f;
    }

    public void TimerRestart()
    {
        Time.timeScale = 1.0f;
    }

    public string GetTime()
    {
        return _TimerText.text;
    }

    public int GetMin()
    {
        return _Min;
    }

    public int GetSec()
    {
        return (int)_Sec;
    }
}
