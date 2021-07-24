using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class cameraMove : MonoBehaviour
{
    public Transform target;        // 따라다닐 타겟 오브젝트의 Transform
 
    private Transform tr;                // 카메라 자신의 Transform
 
    void Start()
    {
        tr = GetComponent<Transform>();
    }
 
    void LateUpdate()
    {
        tr.position = new Vector3(target.position.x -3.974579f, tr.position.y, target.position.z + 3.834952f);
 
        //tr.LookAt(target);
    }
}
