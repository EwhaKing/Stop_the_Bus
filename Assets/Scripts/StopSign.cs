using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSign : MonoBehaviour
{
    float time;
    MeshRenderer mesh;
    Material mat;

    void Start()
    {
        time = 0;
        mesh = GetComponent<MeshRenderer>();
        mat = mesh.material;
    }


    void Update()
    {
        // 1초마다 점선이 깜빡거리게
        if (time < 1f)
            mat.color = new Color(mesh.material.color.r , mesh.material.color.g, mesh.material.color.b, time / 2f);
        else if (time < 2f)
            mat.color = new Color(mesh.material.color.r, mesh.material.color.g, mesh.material.color.b, 1f - time / 2f);
        else
            time = 0;

        time += Time.deltaTime;
    }
}
