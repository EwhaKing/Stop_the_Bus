using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGenerator : MonoBehaviour
{
    public GameObject prefab; //찍어낼 게임 오브젝트
    private BoxCollider area;    //박스콜라이더의 사이즈를 가져오기 위함
    public int count = 100;      //찍어낼 게임 오브젝트 갯수
    
    void Start()
    {
        area = GetComponent<BoxCollider>();
        
        for(int i = 0; i < count; ++i)//count 수 만큼 생성한다
        {
            Spawn();//생성 + 스폰위치를 포함하는 함수
        }
        
        area.enabled = false;
    }
//밑에 코드가 더 있습니다
    private Vector3 GetRandomPosition()
        {
            Vector3 basePosition = transform.position;
            Vector3 size = area.size;
            
            float posX = basePosition.x + Random.Range(-size.x, size.x);
            float posY = basePosition.y + Random.Range(-size.y, size.y);
            float posZ = basePosition.z + Random.Range(-size.z, size.z);
            
            Vector3 spawnPos = new Vector3(posX, posY, posZ);
            
            return spawnPos;
        }
    private void Spawn()
    {
        
        Vector3 spawnPos = GetRandomPosition();//랜덤위치함수
        
        Instantiate(prefab, spawnPos, Quaternion.identity);
    }
}//스크립트 종료