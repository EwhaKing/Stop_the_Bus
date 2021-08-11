using UnityEngine; 
using System.Collections; 


// 새로운 자동차 생성 스크립트
public class car : MonoBehaviour { 

    public GameObject[] prefab; // 사용할 프리팹 종류
    public Transform[] wayPoints; // 프리팹 기본설정으로 심어두려 했는데 안될듯 ㅅㅂ
    public int count;

    public float createTime; // 생성 주기
    public bool isLoop; 

    
    private int rand; // 프리팹 랜덤 설정 변수
    private float timecheck;
    public static int car_count = 0; //전체 생성한 car count 개수
    public static bool tutorial = true;

    
    // Use this for initialization 
    void Start () {
        timecheck = -createTime;
    } 

    // Update is called once per frame 
    void Update () { 

        if (Time.time - timecheck >= createTime && car_count < count && tutorial){
            
            timecheck = Time.time;
            rand = Random.Range(0,prefab.Length);
            
            GameObject myInstance = Instantiate(prefab[rand]); 
         
            //myInstance[car_count].transfrom.position = new Vector3(0, 1.0f, 0); //위치 지정
            myInstance.GetComponent<car_path>().init(isLoop, wayPoints); // 초기화
            myInstance.SetActive(true);
            
            car_count++;
            
        }

    } 

}
