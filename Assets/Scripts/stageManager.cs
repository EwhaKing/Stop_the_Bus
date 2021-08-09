using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class stageManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goStage(int n){
        switch(n){
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
