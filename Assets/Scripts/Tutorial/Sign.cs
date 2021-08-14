using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public GameObject newSign;
    public GameObject removeText;
    public GameObject newText;
    void Start()
    {
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Backwheel")
        {
            Destroy(gameObject); //빨간선 사라지게
            newSign.active = true; //다음 빨간선 보이게
            Destroy(removeText); //현재 설명텍스트 사라지게
            newText.active = true; //다음 설명텍스트 보이게
            car.tutorial = false;
        }
    }
}
