using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Steamworks;

public class Bus : MonoBehaviour{

    public WheelCollider[] colls = new WheelCollider[4]; //바퀴가 돌아가는 걸 표현하기위한 메쉬
    public Transform[] tires = new Transform[4];
    public TextMeshProUGUI speedText;
    public string season = ""; 

    public AudioSource[] effect;

    Rigidbody busBody;
    
    private float mouseSpeed;
    public float accel;             // 마우스 회전속도에 곱해 실제 버스속도를 조절할 가속도값
    public static float velocity;   // 실제 버스 속도
    public static int speed;        // 스크린에 비춰지는 속력

    private float timeCheck;        // 몇 초 동안 속도변화가 일어나지 않고 있는지 체크
    private bool isBreak = false;    // 브레이크 밟는 동안 속도증가 일어나지 않도록 체크
    
    private bool isIce = false;
    private bool isPuddle = false;
    private bool isVerticle = false;    // 버스가 수직으로 서 있는 상태인지

    private float verticleTime = 0f;    // 수직으로 서 있는 시간 체크, 2초 이상이면 아웃
    public static bool isOut = false;  


    void Start()
    {
        busBody = GetComponent<Rigidbody>(); //리지드바디를 받아온다.
        busBody.centerOfMass = new Vector3(0, -0.218f, 0.173f); //무게중심을 가운데로 맞춰서 안정적으로 주행하도록 한다.*/
        mouseSpeed = 0;
        velocity = 0;
        isBreak = false;
        isOut = false;
        isIce = false;
        isVerticle = false;
        verticleTime = 0f;
    }

    private void Update()
    {   
        // 차체가 일직선으로 세워지면 속도 0
        if(Math.Abs(transform.eulerAngles.x) < 100 && Math.Abs(transform.eulerAngles.x) > 80){
            if (!isVerticle){
                isBreak = true;
                verticleTime = Time.time;
                isVerticle = true;
            }
        }
        else isVerticle = false;

        if (isVerticle && Time.time - verticleTime >= 2) isOut = true; // 일직선으로 세워지고 2초가 지나면 아웃

        // 버스 이동
        transform.Translate(Vector3.forward * -velocity * Time.deltaTime * 0.5f);

        // 버스 바퀴 회전
        for (int i=0;i<4;i++)  {
            rotateWheel(i, season);
        }

        // 버스 차체 회전
        rotateBody(season);

        // 급정거
        if (Math.Abs(velocity) > 0 && Input.GetKeyDown(KeyCode.Space)){
            isBreak = true;
            busBody.AddRelativeForce(new Vector3(0, -1, 0) * 1000 * Math.Abs(velocity)); // 덜컹거리는 모션
            busBody.AddRelativeForce(new Vector3(0, 0, -1) * 50000 * Math.Abs(velocity));

            // 브레이크 소리는 일정 속도 이상일때만
            effect[1].volume = Math.Abs(velocity);
            soundEffect(1); 
        }

        if (isBreak) // 속도가 바로 0이 되지 않고 가파르게 줄어듦
        {
            breakBus();
        }
        
        // 속력 text
        speed = (int)(Math.Abs(velocity) * 10);
        speedText.text = speed.ToString();

        // 1초 내에 속도변화가 일어나지 않으면 0.15초에 1씩 줄어듦
        if (velocity != 0 && Time.time - timeCheck >= 0.15) {
            timeCheck = Time.time;
            if (velocity < 0.1f && velocity > -0.1f) velocity = 0;
            else if (velocity > 0) velocity-=0.1f;
            else if (velocity < 0) velocity+=0.1f;
        }

        // 마우스 회전 시 수행내용
        if (Mouse.isSpeeding && !isBreak)
        {
            changeSpeed();
        }
        else {
            mouseSpeed = 0;
        }
        
    }

    void breakBus() // 버스의 속도를 빠르게 0으로 줄임
    {
        for(int i=0;i<4;i++) 
        {
            colls[i].brakeTorque = Mathf.Infinity;
        }
        if (velocity > 0.1f) velocity -=0.15f;
        else if (velocity < -0.1f) velocity +=0.15f;
        else {
            velocity=0;
            isBreak = false;
        }
    }

    void soundEffect(int i){ // 1번은 브레이크 사운드, 2번은 빙판 사운드
        effect[i].Play();
    }

    void changeSpeed(){ //속도변화

        mouseSpeed += 0.0005f * Mouse.crossP; // 

        if (mouseSpeed >= 1) { // 속도가 증가하기 위한 최소한의 마우스 회전속도
            velocity += accel;
            
            // 마우스 회전 속도에 따른 추가속도 더하기
            if (mouseSpeed >= 10) velocity += mouseSpeed * 0.001f;
            mouseSpeed = 0;
            timeCheck = Time.time;
        }
        else if (mouseSpeed <= -1){
            velocity -= accel;

            if (mouseSpeed <= -10) velocity += mouseSpeed * 0.001f;
            mouseSpeed = 0;
            timeCheck = Time.time;
        }
    }

    // 차체 회전
    void rotateBody(string seasons){

        switch(seasons){

            case "winter":  // 아이스를 밟으면 회전 불가
                if(!isIce){
                    if (Math.Abs(velocity) <= 2)  transform.Rotate(Vector3.up * 0.15f * velocity *Input.GetAxis("Horizontal"));
                    else if (Math.Abs(velocity) < 7)  transform.Rotate(Vector3.up * 0.14f * velocity *Input.GetAxis("Horizontal"));
                    else if (velocity > 0) transform.Rotate(Vector3.up * 0.14f * 7 *Input.GetAxis("Horizontal"));
                    else if (velocity < 0) transform.Rotate(Vector3.up * 0.14f * -7 *Input.GetAxis("Horizontal"));
                }
                break;

            case "summer":  // 물 웅덩이를 밟으면 반대로 회전
                if(!isPuddle){
                    if (Math.Abs(velocity) <= 2)  transform.Rotate(Vector3.up * 0.15f * velocity *Input.GetAxis("Horizontal"));
                    else if (Math.Abs(velocity) < 7)  transform.Rotate(Vector3.up * 0.14f * velocity *Input.GetAxis("Horizontal"));
                    else if (velocity > 0) transform.Rotate(Vector3.up * 0.14f * 7 *Input.GetAxis("Horizontal"));
                    else if (velocity < 0) transform.Rotate(Vector3.up * 0.14f * -7 *Input.GetAxis("Horizontal"));
                }
                else{
                    if (Math.Abs(velocity) <= 2)  transform.Rotate(Vector3.up * 0.15f * -velocity *Input.GetAxis("Horizontal"));
                    else if (Math.Abs(velocity) < 7)  transform.Rotate(Vector3.up * 0.14f * -velocity *Input.GetAxis("Horizontal"));
                    else if (velocity > 0) transform.Rotate(Vector3.up * 0.14f * -7 *Input.GetAxis("Horizontal"));
                    else if (velocity < 0) transform.Rotate(Vector3.up * 0.14f * 7 *Input.GetAxis("Horizontal"));
                }
                break;

            default:    // 속도에 비례해서 회전 각을 크게 함, 70 이상부터는 같은 각도로 회전
                if (Math.Abs(velocity) <= 2)  transform.Rotate(Vector3.up * 0.15f * velocity *Input.GetAxis("Horizontal"));
                else if (Math.Abs(velocity) < 7)  transform.Rotate(Vector3.up * 0.14f * velocity *Input.GetAxis("Horizontal"));
                else if (velocity > 0) transform.Rotate(Vector3.up * 0.14f * 7 *Input.GetAxis("Horizontal"));
                else if (velocity < 0) transform.Rotate(Vector3.up * 0.14f * -7 *Input.GetAxis("Horizontal"));
                break;
        }

    }

    void rotateWheel(int wheel, string seasons){

        if (colls[wheel].rpm > 1) {
            colls[wheel].brakeTorque = Mathf.Infinity;
        }       

        // 버스가 움직일때 굴러가는 바퀴
        if (Math.Abs(velocity) <= 2) tires[wheel].Rotate(Vector3.right * -velocity * Time.deltaTime * 20);
        else if (Math.Abs(velocity) <= 3) tires[wheel].Rotate(Vector3.right * -velocity * Time.deltaTime * 18);
        else if (velocity < 0) tires[wheel].Rotate(Vector3.right * Time.deltaTime * 54);
        else if (velocity > 0) tires[wheel].Rotate(Vector3.right * -Time.deltaTime * 54);

        // 앞바퀴 좌우 회전
        switch(seasons){
            case "summer":
            // 물웅덩이에 닿지 않을때 - 회전방향 정상
            if (!isPuddle && wheel%2==1){ 
                if (Math.Abs(velocity) < 5) tires[wheel].localRotation = Quaternion.Euler( -velocity * 100, 3* Input.GetAxis("Horizontal") * Math.Abs(velocity) ,0);
                else tires[wheel].localRotation = Quaternion.Euler( -velocity * 100, Input.GetAxis("Horizontal") * 15 ,0);
            }
            // 물웅덩이에 닿을때 - 회전방향 반대
            else if (isPuddle && wheel%2==1){
                if (Math.Abs(velocity) < 5) tires[wheel].localRotation = Quaternion.Euler( -velocity * 100, -3* Input.GetAxis("Horizontal") * Math.Abs(velocity) ,0);
                else tires[wheel].localRotation = Quaternion.Euler( -velocity * 100, -Input.GetAxis("Horizontal") * 15 ,0);     
            }
            break;

            default:
            if (wheel%2==1){ 
                if (Math.Abs(velocity) < 5) tires[wheel].localRotation = Quaternion.Euler( -velocity * 100, 3* Input.GetAxis("Horizontal") * Math.Abs(velocity) ,0);
                else tires[wheel].localRotation = Quaternion.Euler( -velocity * 100, Input.GetAxis("Horizontal") * 15 ,0);
            }
            break;
        }

            
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("gameOver")) // 범위 벗어나서 콜라이더에 닿으면 게임 오버
        { 
            //outCheck.gameOver();
            isOut = true;
            return;
        }
        
        if (col.gameObject.CompareTag("gravel")){ // 자갈밭 가속도 증가
            accel = 0.02f;
            return;
        }
        else if(col.gameObject.CompareTag("BlackIce") && isIce == false)
        {
            isIce = true;
            soundEffect(2); // 아이스 밟았을때 소리
            return;
        }
        else if (col.gameObject.name == "farm"){ // 히든 도전과제 - 밭에 떨어지기
            bool isAchieved = false;
            SteamUserStats.GetAchievement("TEARS_OF_FARMER", out isAchieved);
            if (isAchieved) return; // 이미 달성했다면 그냥 빠져나옴
            SteamUserStats.SetAchievement("TEARS_OF_FARMER");
            SteamUserStats.StoreStats();
        }
    }

    void OnTriggerStay(Collider col) 
    {
        if(col.gameObject.CompareTag("BlackIce")) isIce = true;
        else if(col.gameObject.CompareTag("puddle")) isPuddle = true;
    }

    void OnTriggerExit(Collider col){
        if (col.gameObject.CompareTag("gravel")){
            accel = 0.01f;
            return;
        }
        else if(col.gameObject.CompareTag("BlackIce")) isIce = false;
        else if(col.gameObject.CompareTag("puddle")) isPuddle = false;        
    }
    
    void OnCollisionEnter(Collision col){
        if (col.collider.CompareTag("gameOver")){
            isOut = true;
            return;
        }
        if (col.collider.CompareTag("car")){    // 도전과제 - 자동차랑 부딪히기 (도로 위의 무법자)
            bool flag;
            SteamUserStats.GetAchievement("GANG_ON_THE_LOAD", out flag);
            if (flag) return;
            SteamUserStats.SetAchievement("GANG_ON_THE_LOAD");
            SteamUserStats.StoreStats();
        }
    }

}