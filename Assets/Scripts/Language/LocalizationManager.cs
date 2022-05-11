using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LocalizationManager : MonoBehaviour
{

    public static LocalizationManager instance;
    private Dictionary<string, string> localizedText;
    private string missingTextString = "Localized text not found";


    // Start is called before the first frame update
    void Awake()
    {
        //싱글톤 패턴
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
 
        } else if (instance != this) {
        //Instance is not the same as the one we have, destroy old one, and reset to newest one
            Destroy(gameObject);
        }
        
        if (PlayerPrefs.HasKey("lang")) {
            LoadLocalizedText(PlayerPrefs.GetString("lang"));
        }
        else LoadLocalizedText("localizedText_en");
    }


    // 설정화면에서 언어 변경시 실행
    public void LoadLocalizedText(string fileName)
    {   
        PlayerPrefs.SetString("lang",fileName);
        localizedText = new Dictionary<string, string>();

        // StreamingAssetsPath에서 fineName 의 경로를 가져오기
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);
        filePath += ".txt";
        if (File.Exists(filePath))
        {
            // json파일을 읽어서 string으로 뽑음
            string dataAsJson = File.ReadAllText(filePath); 
            LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);    //deserialization

            //전체 아이템들에 대해서
            for (int i = 0; i < loadedData.items.Length; i++)
            {
                localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);
            }
        }
        else
        {
            //파일이 존재하지않으면
            Debug.LogError("Cannot find file"); 
        }

    }

    // key 각각에 대한 번역값 value 가져오기
    public string GetLocalizedValue(string key)
    {   
        string result = missingTextString;
        if(localizedText.ContainsKey(key))
        {
            result = localizedText[key];
        }

        return result;
    }

}