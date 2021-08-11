using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSign : MonoBehaviour
{
    string wheel;
    bool wheel1, wheel2, wheel3, wheel4;

    void Start()
    {
        wheel1 = false;
        wheel2 = false;
        wheel3 = false;
        wheel4 = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider coll)
    {
        wheel = coll.gameObject.name;
        if (wheel == "BUS_wheelLB")
            wheel1 = true;
        else if (wheel == "BUS_wheelLF")
            wheel2 = true;
        else if (wheel == "BUS_wheelRB")
            wheel3 = true;
        else if (wheel == "BUS_wheelRF")
            wheel4 = true;

        //if (wheel1 && wheel2 && wheel3 && wheel4)

    }
}