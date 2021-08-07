using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tutotextLeft : MonoBehaviour
{
    TextMeshProUGUI flashingText; 
    
    void Start (){ 
        flashingText = GetComponent<TextMeshProUGUI> (); 
        StartCoroutine (BlinkText()); } 
        
    public IEnumerator BlinkText(){ 
        while (true) 
        { flashingText.text = ""; 
          yield return new WaitForSeconds (2f); 
          flashingText.text = "A를 누른 채로 마우스를 돌려\n커브를 도세요!"; 
          yield return new WaitForSeconds (1f); } 
    } 
}