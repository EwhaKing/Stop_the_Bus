using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tutoCustomer : MonoBehaviour
{
    TextMeshProUGUI flashingText; 
    
    void Start (){ 
        flashingText = GetComponent<TextMeshProUGUI> (); 
        StartCoroutine (BlinkText()); } 
        
    public IEnumerator BlinkText(){ 
        while (true) 
        { 
          flashingText.text = "           손님을 태우세요!"; 
          yield return new WaitForSeconds (1f); 
          flashingText.text = ""; 
          yield return new WaitForSeconds (2f); } 
    } 
}
