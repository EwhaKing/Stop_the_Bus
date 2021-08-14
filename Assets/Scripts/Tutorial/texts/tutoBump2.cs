using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tutoBump2 : MonoBehaviour
{
    TextMeshProUGUI flashingText; 
    
    void Start (){ 
        flashingText = GetComponent<TextMeshProUGUI> (); 
        StartCoroutine (BlinkText()); } 
        
    public IEnumerator BlinkText(){ 
        while (true) 
        { 
          flashingText.text = "(표지판의 속도 이상인 상태에서 방지턱을 지나면 안됩니다)"; 
          yield return new WaitForSeconds (1f); 
          flashingText.text = ""; 
          yield return new WaitForSeconds (2f); } 
    } 
}
