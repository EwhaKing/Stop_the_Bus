using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class miniBus : MonoBehaviour
{
    public Transform target;        // 실제 버스 오브젝트의 Transform
    private Transform me;                // 미니맵 버스의 Transform

    public float x; //-3.974579f
    public float y; //
    public float z; //3.834952f

    public static int rotat = 0;


    //public static 

 
    void Start()
    {
        me = GetComponent<Transform>();
    }
 
    void LateUpdate()
    {/*
        if (rotat != 0) {
            transform.Rotate(Vector3.up * 90);
            rotat = 0;
        }*/
        me.position = new Vector3(target.position.x + x, me.position.y, target.position.z + z);
        
        
        //tr.LookAt(target);
    }
}
