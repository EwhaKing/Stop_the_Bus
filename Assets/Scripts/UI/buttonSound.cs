
using UnityEngine;

using System.Collections;

public class buttonSound : MonoBehaviour {

    private GameObject btn;

    void Start(){
        btn = GameObject.Find("btnaudio");
    }
    public void ButtonClick(){
        btn.GetComponent<AudioSource>().Play();
        
    }

    
}

