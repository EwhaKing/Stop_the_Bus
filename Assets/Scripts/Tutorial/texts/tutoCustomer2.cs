using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tutoCustomer2 : MonoBehaviour
{
    TextMeshProUGUI flashingText; 
    
    void Start (){ 
        flashingText = GetComponent<TextMeshProUGUI> (); 
        StartCoroutine (BlinkText()); } 
        
    public IEnumerator BlinkText(){ 
        while (true) 
        { 
          flashingText.text = "하얀 점선 안으로 들어가서 기다리세요\n(손님이 많을수록 오래 걸립니다)"; 
          yield return new WaitForSeconds (1f); 
          flashingText.text = ""; 
          yield return new WaitForSeconds (2f); } 
    } 
}
