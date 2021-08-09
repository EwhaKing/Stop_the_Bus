using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableKey : MonoBehaviour
{
    public static bool key = true;

    void Update() {
        if (!key){
            if(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D))
            {
                disableKey.key = false;
            }
        }
    }
    void OnTriggerEnter(Collider col)
        {
            if(col.gameObject.tag == "Bus")
            {
                key = false;
            }
        }
}