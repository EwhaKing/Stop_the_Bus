using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Screen.SetResolution(1056, 824, false);
    }
}
