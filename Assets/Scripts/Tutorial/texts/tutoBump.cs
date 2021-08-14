using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tutoBump : MonoBehaviour
{
    TextMeshProUGUI flashingText; 
    
    void Start (){ 
        flashingText = GetComponent<TextMeshProUGUI> (); 
        StartCoroutine (BlinkText()); } 
        
    public IEnumerator BlinkText(){ 
        while (true) 
        { 
          flashingText.text = "표지판의 속도 미만으로 운전하세요!";
          yield return new WaitForSeconds (1f); 
          flashingText.text = ""; 
          yield return new WaitForSeconds (2f); } 
    } 
}
