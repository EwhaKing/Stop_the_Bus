using UnityEngine; 
using System.Collections; 


// 새로운 자동차 생성 스크립트
public class Car : MonoBehaviour { 

    public GameObject[] cars;       // 사용할 자동차 종류
    public Transform[] wayPoints;   // 이동할 경로 포인트들
    public int count;               // 생성할 자동차 개수

    public float createTime;        // 생성 주기
    public bool isLoop;             // 루프경로인지

    private int rand;               // 프리팹 랜덤 설정 변수
    private float recentCreate;     // 가장 최근 생성한 시각
    public static int carCount = 0; // 생성한 개수

    public static bool tutorial = true;  // 튜토리얼 맵에서 자동차 구간 넘어가면 자동차 생성 X

    void Start () {
        tutorial = true;
        recentCreate = -createTime;
        carCount = 0;
    } 
 
    void Update () { 

        // 생성 주기마다 1개씩 자동차 생성, 전체 개수를 채우면 생성 안함
        if (Time.time - recentCreate >= createTime && carCount < count && tutorial)
        {
            createCar();
        }

    } 

    void createCar()
    {
        recentCreate = Time.time; // 최근 생성 시각
        rand = Random.Range(0,cars.Length);
        
        GameObject myInstance = Instantiate(cars[rand]); // 랜덤 프리팹 인스턴스 생성
        
        //myInstance[carCount].transfrom.position = new Vector3(0, 1.0f, 0); //위치 지정
        myInstance.GetComponent<CarPath>().init(isLoop, wayPoints); // 초기화
        myInstance.SetActive(true);
        
        carCount++;
    }


    /* 게임 일시정지 함수 나중에 다른 스크립트로 옮길 것 */
    public void pauseBus(){
        Time.timeScale = 0f;
    }

    public void playBus(){
        Time.timeScale = 1f;
    }

}
