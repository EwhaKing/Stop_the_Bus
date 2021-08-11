using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackIce : MonoBehaviour
{
    public GameObject prefab; 
    public Transform target;

    public float x;
    public float y;
    public float z;

    public static int rotat = 0;
    public int count = 20;      //찍어낼 게임 오브젝트 갯수
    
    void Start()
    {
        
        for(int i = 0; i < count; ++i)//count 수 만큼 생성한다
        {
            Spawn();//생성 + 스폰위치를 포함하는 함수
        }
        
    }
    private Vector3 GetRandomPosition()
    {
        
        float posX = Random.Range(-50, 66);
        float posY = Random.Range(0.57f, 1);
        float posZ = Random.Range(-40, 40);
        
        Vector3 spawnPos = new Vector3(posX, posY, posZ);
        
        return spawnPos;
    }
    private void Spawn()
    {
        
        Vector3 spawnPos = GetRandomPosition();//랜덤위치함수
        
        Instantiate(prefab, spawnPos, Quaternion.identity);
    }
}