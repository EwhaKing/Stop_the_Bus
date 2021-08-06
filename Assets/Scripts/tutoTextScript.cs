using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutoTextScript : MonoBehaviour
{
    Text flashingText; 
    
    void Start () { 
        flashingText = GetComponent<Text> (); 
        StartCoroutine (BlinkText()); } 
    
    public IEnumerator BlinkText(){ 
        while (true) 
        { flashingText.text = ""; 
          yield return new WaitForSeconds (2f); 
          flashingText.text = "마우스를 동그랗게 돌려주세요!"; 
          yield return new WaitForSeconds (1f); } 
    } 
}
