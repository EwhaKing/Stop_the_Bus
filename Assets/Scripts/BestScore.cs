using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    //계절별 기록 창
    public Text SpringCusText;
    public Text SpringTimeText;
    public Image SpringFace;

    public Text SummerCusText;
    public Text SummerTimeText;
    public Image SummerFace;

    public Text FallCusText;
    public Text FallTimeText;
    public Image FallFace;

    public Text WinterCusText;
    public Text WinterTimeText;
    public Image WinterFace;

    /*void Start()
    {
       PlayerPrefs.DeleteAll();     //기록 삭제
    }*/

    //봄 기록
    public static void UpdateSpring(int ComfortNum, int Min, int Sec, int Passengers)
    {
        //기록이 없을 때
        if (!PlayerPrefs.HasKey("SpringComfortNum"))    //하나로 판별
        {
            PlayerPrefs.SetInt("SpringComfortNum", ComfortNum);
            PlayerPrefs.SetInt("SpringMin", Min);
            PlayerPrefs.SetInt("SpringSec", Sec);
            PlayerPrefs.SetInt("SpringPass", Passengers);
            return;
        }

        //기록 있을 때
        int SpringComfortNum = PlayerPrefs.GetInt("SpringComfortNum");
        int SpringMin = PlayerPrefs.GetInt("SpringMin");
        int SpringSec = PlayerPrefs.GetInt("SpringSec");
        int SpringPass = PlayerPrefs.GetInt("SpringPass");

        if (ComfortNum > SpringComfortNum)         //만족도 비교
        {
            PlayerPrefs.SetInt("SpringComfortNum", ComfortNum);
            PlayerPrefs.SetInt("SpringMin", Min);
            PlayerPrefs.SetInt("SpringSec", Sec);
            PlayerPrefs.SetInt("SpringPass", Passengers);
        }
        else if (ComfortNum == SpringComfortNum)    //만족도가 같으면 시간 비교
        {
            if (Min < SpringMin)
            {
                PlayerPrefs.SetInt("SpringMin", Min);
                PlayerPrefs.SetInt("SpringSec", Sec);
                PlayerPrefs.SetInt("SpringPass", Passengers);
            }
            else if (Min == SpringMin)
            {
                if (Sec < SpringSec)
                {
                    PlayerPrefs.SetInt("SpringSec", Sec);
                    PlayerPrefs.SetInt("SpringPass", Passengers);
                }
                else if (Sec == SpringSec)          //시간이 같으면 손님수 비교 
                {
                    if (Passengers > SpringPass)
                        PlayerPrefs.SetInt("SpringPass", Passengers);
                }
            }

        }
    }


    //여름 기록
    public static void UpdateSummer(int ComfortNum, int Min, int Sec, int Passengers)
    {
        //기록이 없을 때
        if (!PlayerPrefs.HasKey("SummerComfortNum"))    //하나로 판별
        {
            PlayerPrefs.SetInt("SummerComfortNum", ComfortNum);
            PlayerPrefs.SetInt("SummerMin", Min);
            PlayerPrefs.SetInt("SummerSec", Sec);
            PlayerPrefs.SetInt("SummerPass", Passengers);
            return;
        }

        //기록 있을 때
        int SummerComfortNum = PlayerPrefs.GetInt("SummerComfortNum");
        int SummerMin = PlayerPrefs.GetInt("SummerMin");
        int SummerSec = PlayerPrefs.GetInt("SummerSec");
        int SummerPass = PlayerPrefs.GetInt("SummerPass");

        if (ComfortNum > SummerComfortNum)         //만족도 비교
        {
            PlayerPrefs.SetInt("SummerComfortNum", ComfortNum);
            PlayerPrefs.SetInt("SummerMin", Min);
            PlayerPrefs.SetInt("SummerSec", Sec);
            PlayerPrefs.SetInt("SummerPass", Passengers);
        }
        else if (ComfortNum == SummerComfortNum)    //만족도가 같으면 시간 비교
        {
            if (Min < SummerMin)
            {
                PlayerPrefs.SetInt("SummerMin", Min);
                PlayerPrefs.SetInt("SummerSec", Sec);
                PlayerPrefs.SetInt("SummerPass", Passengers);
            }
            else if (Min == SummerMin)
            {
                if (Sec < SummerSec)
                {
                    PlayerPrefs.SetInt("SummerSec", Sec);
                    PlayerPrefs.SetInt("SummerPass", Passengers);
                }
                else if (Sec == SummerSec)          //시간이 같으면 손님수 비교 
                {
                    if (Passengers > SummerPass)
                        PlayerPrefs.SetInt("SummerPass", Passengers);
                }
            }

        }
    }


    //가을 기록
    public static void UpdateFall(int ComfortNum, int Min, int Sec, int Passengers)
    {
        //기록이 없을 때
        if (!PlayerPrefs.HasKey("FallComfortNum"))    //하나로 판별
        {
            PlayerPrefs.SetInt("FallComfortNum", ComfortNum);
            PlayerPrefs.SetInt("FallMin", Min);
            PlayerPrefs.SetInt("FallSec", Sec);
            PlayerPrefs.SetInt("FallPass", Passengers);
            return;
        }

        //기록 있을 때
        int FallComfortNum = PlayerPrefs.GetInt("FallComfortNum");
        int FallMin = PlayerPrefs.GetInt("FallMin");
        int FallSec = PlayerPrefs.GetInt("FallSec");
        int FallPass = PlayerPrefs.GetInt("FallPass");

        if (ComfortNum > FallComfortNum)         //만족도 비교
        {
            PlayerPrefs.SetInt("FallComfortNum", ComfortNum);
            PlayerPrefs.SetInt("FallMin", Min);
            PlayerPrefs.SetInt("FallSec", Sec);
            PlayerPrefs.SetInt("FallPass", Passengers);
        }
        else if (ComfortNum == FallComfortNum)    //만족도가 같으면 시간 비교
        {
            if (Min < FallMin)
            {
                PlayerPrefs.SetInt("FallMin", Min);
                PlayerPrefs.SetInt("FallSec", Sec);
                PlayerPrefs.SetInt("FallPass", Passengers);
            }
            else if (Min == FallMin)
            {
                if (Sec < FallSec)
                {
                    PlayerPrefs.SetInt("FallSec", Sec);
                    PlayerPrefs.SetInt("FallPass", Passengers);
                }
                else if (Sec == FallSec)          //시간이 같으면 손님수 비교 
                {
                    if (Passengers > FallPass)
                        PlayerPrefs.SetInt("FallPass", Passengers);
                }
            }
        }
    }


    //겨울 기록
    public static void UpdateWinter(int ComfortNum, int Min, int Sec, int Passengers)
    {
        //기록이 없을 때
        if (!PlayerPrefs.HasKey("WinterComfortNum"))    //하나로 판별
        {
            PlayerPrefs.SetInt("WinterComfortNum", ComfortNum);
            PlayerPrefs.SetInt("WinterMin", Min);
            PlayerPrefs.SetInt("WinterSec", Sec);
            PlayerPrefs.SetInt("WinterPass", Passengers);
            return;
        }

        //기록 있을 때
        int WinterComfortNum = PlayerPrefs.GetInt("WinterComfortNum");
        int WinterMin = PlayerPrefs.GetInt("WinterMin");
        int WinterSec = PlayerPrefs.GetInt("WinterSec");
        int WinterPass = PlayerPrefs.GetInt("WinterPass");

        if (ComfortNum > WinterComfortNum)         //만족도 비교
        {
            PlayerPrefs.SetInt("WinterComfortNum", ComfortNum);
            PlayerPrefs.SetInt("WinterMin", Min);
            PlayerPrefs.SetInt("WinterSec", Sec);
            PlayerPrefs.SetInt("WinterPass", Passengers);
        }
        else if (ComfortNum == WinterComfortNum)    //만족도가 같으면 시간 비교
        {
            if (Min < WinterMin)
            {
                PlayerPrefs.SetInt("WinterMin", Min);
                PlayerPrefs.SetInt("WinterSec", Sec);
                PlayerPrefs.SetInt("WinterPass", Passengers);
            }
            else if (Min == WinterMin)
            {
                if (Sec < WinterSec)
                {
                    PlayerPrefs.SetInt("WinterSec", Sec);
                    PlayerPrefs.SetInt("WinterPass", Passengers);
                }
                else if (Sec == WinterSec)          //시간이 같으면 손님수 비교 
                {
                    if (Passengers > WinterPass)
                        PlayerPrefs.SetInt("WinterPass", Passengers);
                }
            }
        }
    }

    private void Update()
    {
        //봄
        if(PlayerPrefs.HasKey("SpringComfortNum"))
        {
            SpringCusText.text = PlayerPrefs.GetInt("SpringPass").ToString();
            SpringTimeText.text = string.Format("{0:D2}:{1:D2}", PlayerPrefs.GetInt("SpringMin"), PlayerPrefs.GetInt("SpringSec"));
            if (PlayerPrefs.GetInt("SpringComfortNum") == 1)
                SpringFace.sprite = Resources.Load<Sprite>("UI/기록_좋음");
            else if(PlayerPrefs.GetInt("SpringComfortNum") == 0)
                SpringFace.sprite = Resources.Load<Sprite>("UI/기록_보통");
            else
                SpringFace.sprite = Resources.Load<Sprite>("UI/기록_나쁨");
        }

        //여름
        if (PlayerPrefs.HasKey("SummerComfortNum"))
        {
            SummerCusText.text = PlayerPrefs.GetInt("SummerPass").ToString();
            SummerTimeText.text = string.Format("{0:D2}:{1:D2}", PlayerPrefs.GetInt("SummerMin"), PlayerPrefs.GetInt("SummerSec"));
            if (PlayerPrefs.GetInt("SummerComfortNum") == 1)
                SummerFace.sprite = Resources.Load<Sprite>("UI/기록_좋음");
            else if (PlayerPrefs.GetInt("SummerComfortNum") == 0)
                SummerFace.sprite = Resources.Load<Sprite>("UI/기록_보통");
            else
                SummerFace.sprite = Resources.Load<Sprite>("UI/기록_나쁨");
        }

        //가을
        if (PlayerPrefs.HasKey("FallComfortNum"))
        {
            FallCusText.text = PlayerPrefs.GetInt("FallPass").ToString();
            FallTimeText.text = string.Format("{0:D2}:{1:D2}", PlayerPrefs.GetInt("FallMin"), PlayerPrefs.GetInt("FallSec"));
            if (PlayerPrefs.GetInt("FallComfortNum") == 1)
                FallFace.sprite = Resources.Load<Sprite>("UI/기록_좋음");
            else if (PlayerPrefs.GetInt("FallComfortNum") == 0)
                FallFace.sprite = Resources.Load<Sprite>("UI/기록_보통");
            else
                FallFace.sprite = Resources.Load<Sprite>("UI/기록_나쁨");
        }

        //겨울
        if (PlayerPrefs.HasKey("WinterComfortNum"))
        {
            WinterCusText.text = PlayerPrefs.GetInt("WinterPass").ToString();
            WinterTimeText.text = string.Format("{0:D2}:{1:D2}", PlayerPrefs.GetInt("WinterMin"), PlayerPrefs.GetInt("WinterSec"));
            if (PlayerPrefs.GetInt("WinterComfortNum") == 1)
                WinterFace.sprite = Resources.Load<Sprite>("UI/기록_좋음");
            else if (PlayerPrefs.GetInt("WinterComfortNum") == 0)
                WinterFace.sprite = Resources.Load<Sprite>("UI/기록_보통");
            else
                WinterFace.sprite = Resources.Load<Sprite>("UI/기록_나쁨");
        }
    }
}
