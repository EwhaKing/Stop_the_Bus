using UnityEngine; 
using System.Collections; 
using System;

// 생성된 자동차 각각에 대한 이동 스크립트, 자동차 프리팹에 심을 예정
public class CarPath : MonoBehaviour { 

    private Transform[] wayPoints; // 계절 맵별로 지정해줄거임, 자동차 스크립트에서 받아옴

    private bool isInit = false;
    private bool isLoop = true;
    private Transform currentPoint; 
    private int currentIndex; 

    float speed;      // 인스턴스마다 랜덤한 스피드도 괜찮겠다. 근데 자동차들끼리 부딪힐 수 있으니 일정하게 하는걸로
    float minDistance; 


    void Awake() { 

        speed = 8.0f; 
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

        if (isInit) MoveTowardWaypoint();   // 다음 포인트를 향해 이동
        
    } 

    void MoveTowardWaypoint() 
    { 
        Vector3 direction = currentPoint.position - transform.position;        // 현재 위치로부터 목표지점까지의 거리
        Vector3 moveVector = direction.normalized * speed * Time.deltaTime;    // 매 프레임마다 목표지점을 향해 균일한 속도로 이동
        transform.position += moveVector; 
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 4 * Time.deltaTime); // 스무스한 회전

        if (Vector3.Distance(currentPoint.transform.position, transform.position ) < minDistance) 
        { 
            // 목표지점에 충분히 가까워졌으면 다음 목표로 이동
            ++currentIndex; 

            if (currentIndex > wayPoints.Length - 1) { 
                if (isLoop) currentIndex = 0; 
                else {
                    Destroy(gameObject);    // 루프가 없다면 도착지점에서 삭제
                    Car.carCount--;
                    return;
                }
            } 
            currentPoint = wayPoints[currentIndex]; 
        }
    } 
}