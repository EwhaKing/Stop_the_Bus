using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tutotextEnd : MonoBehaviour
{
    TextMeshProUGUI flashingText; 
    
    void Start (){ 
        flashingText = GetComponent<TextMeshProUGUI> (); 
        StartCoroutine (BlinkText()); } 
        
    public IEnumerator BlinkText(){ 
        while (true) 
        { 
          flashingText.text = "빨간 점선 안으로 들어가면 게임이 끝납니다";
          yield return new WaitForSeconds (1f); 
          flashingText.text = ""; 
          yield return new WaitForSeconds (2f); } 
    } 
}
