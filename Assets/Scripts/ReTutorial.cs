using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() { //이 오브젝트가 클릭됐을 때
        Application.LoadLevel (1);
    }
}
