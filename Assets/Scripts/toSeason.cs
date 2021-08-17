using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class toSeason : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {
        
    }

}
