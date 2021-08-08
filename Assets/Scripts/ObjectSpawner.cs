using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private int objectSpawnCount = 20;

    [SerializeField]
    private GameObject prefab;

    private void Awake(){
        for (int i = 0; i<objectSpawnCount; ++i){
            float x = Random.Range(-50.5f, 53.4f);
            float y = Random.Range(0, 23.5f);
            float z = Random.Range(-38, 40);
            Vector3 position = new Vector3(x,y,z);

            Instantiate(prefab, position, Quaternion.identity);
        }
    }
}


