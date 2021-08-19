
using UnityEngine;

using System.Collections;

public class buttonSound : MonoBehaviour {

    void Start () {

    }

    public void ButtonClick(){
        gameObject.GetComponent<AudioSource>().Play();
        DontDestroyOnLoad(gameObject);
        soundOff();
    }

    IEnumerator soundOff(){
        yield return new WaitForSeconds(5f);
        GameObject.Destroy(gameObject);
    }
}

