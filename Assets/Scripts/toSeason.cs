using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class toSeason : MonoBehaviour
{
    private float timeSpan;
    private float checkTime;

    // Start is called before the first frame update
    void Start()
    {      
        timeSpan = 0.0f;
        checkTime = 4.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeSpan += Time.deltaTime;

        if (timeSpan >= checkTime)
        {
            switch (toLoading.ld)
            {
                case 0:
                    SceneManager.LoadScene("spring");
                    break;
                case 1:
                    SceneManager.LoadScene("Summer");
                    break;
                case 2:
                    SceneManager.LoadScene("fall");
                    break;
                case 3:
                    SceneManager.LoadScene("Winter");
                    break;
            }
        }
    }

}
