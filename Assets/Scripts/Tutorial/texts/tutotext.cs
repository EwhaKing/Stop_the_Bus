using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tutotext : MonoBehaviour
{
    TextMeshProUGUI flashingText; 
    
    void Start (){ 
        flashingText = GetComponent<TextMeshProUGUI> (); 
        StartCoroutine (BlinkText()); } 
        
    public IEnumerator BlinkText(){ 
        while (true) 
        { 
          flashingText.text = "마우스를 동그랗게 돌려주세요!"; 
          yield return new WaitForSeconds (1f); 
          flashingText.text = ""; 
          yield return new WaitForSeconds (2f); } 
    } 
}