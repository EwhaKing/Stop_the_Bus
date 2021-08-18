using UnityEngine; 
using System.Collections; 
using System;

// 생성된 자동차 각각에 대한 이동 스크립트, 자동차 프리팹에 심을 스크립트
public class car_path : MonoBehaviour { 

    private Transform[] wayPoints; // 프리팹 기본설정으로 심어둘 예정

    private bool isInit = false;
    private bool isLoop = true;
    private Transform currentPoint; 
    private int currentIndex; 

    private float timecheck = 0;

    float speed; 
    float minDistance; 


    void Awake() { 

        speed = 8.0f; //스피드도 다양하게 할 수는 있긴함, 근데 일정속도로 지나가도 괜찮을 것 같음..
        minDistance = 0.6f; 

    } 
    
    // Use this for initialization 
    void Start () {

        if (isInit)
        {
            if (isLoop) currentPoint = wayPoints[0]; 
            else currentPoint = wayPoints[1]; 
            currentIndex = 0; 
        }        

    } 

    public void init(bool loop, Transform[] wp){
        // 초기화
        isLoop = loop;
        wayPoints = new Transform[wp.Length];
        for (int i=0; i<wp.Length; i++) wayPoints[i] = wp[i];
        if (!isLoop) transform.position = wayPoints[0].position;
        else transform.position = wayPoints[wp.Length - 1].position;
        isInit = true;
    }

    // Update is called once per frame 
    void Update () { 

        if (isInit){
            MoveTowardWaypoint(); 

            if (Vector3.Distance( currentPoint.transform.position, transform.position ) < minDistance) { 
                ++currentIndex; 
                if (currentIndex > wayPoints.Length - 1) { 
                    if (isLoop) currentIndex = 0; 
                    else {

                        Destroy(gameObject); //자기자신 삭제
                        car.car_count--;
                        return;
                    }
                } 
                currentPoint = wayPoints[currentIndex]; 
            }
        }
        
    } 

    void MoveTowardWaypoint() { 

        Vector3 vDirection = currentPoint.position - transform.position; // 다음위치와 오브젝트간 거리
        Vector3 vMoveVector = vDirection.normalized * speed * Time.deltaTime; // 이동벡터?
        transform.position += vMoveVector; //매 프레임마다 이동벡터만큼 이동
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(vDirection), 4 * Time.deltaTime); // 다음 waypoint로 회전
    } 
}