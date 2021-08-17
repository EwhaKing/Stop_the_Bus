using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class toLoading : MonoBehaviour
{
    public static int ld;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Load(int n)
    {
        ld = n;

        switch (ld)
        {
            case 0:
            case 2:
                SceneManager.LoadScene("LoadingSF");
                break;
            case 1:
            case 3:
                SceneManager.LoadScene("LoadingSW");
                break;
        }
    }
}
