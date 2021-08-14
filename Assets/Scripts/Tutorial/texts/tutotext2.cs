using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tutotext2 : MonoBehaviour
{
    TextMeshProUGUI flashingText; 
    
    void Start (){ 
        flashingText = GetComponent<TextMeshProUGUI> (); 
        StartCoroutine (BlinkText()); } 
        
    public IEnumerator BlinkText(){ 
        while (true) 
        { 
          flashingText.text = "(반대차선의 자동차와 닿지 않도록 주의하세요)"; 
          yield return new WaitForSeconds (1f); 
          flashingText.text = ""; 
          yield return new WaitForSeconds (2f); } 
    } 
}
