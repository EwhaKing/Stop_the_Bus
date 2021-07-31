using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class cameraMove : MonoBehaviour
{
    public Transform target;        // 따라다닐 타겟 오브젝트의 Transform
    private Transform tr;                // 카메라 자신의 Transform

    public float x; //-3.974579f
    public float y; //
    public float z; //3.834952f

    public static int rotat = 0;


    //public static 

 
    void Start()
    {
        tr = GetComponent<Transform>();
    }
 
    void LateUpdate()
    {/*
        if (rotat != 0) {
            transform.Rotate(Vector3.up * 90);
            rotat = 0;
        }*/
        tr.position = new Vector3(target.position.x + x, target.position.y + y, target.position.z + z);
        
        
        //tr.LookAt(target);
    }
}
