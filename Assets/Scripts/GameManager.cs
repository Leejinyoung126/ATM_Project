using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public UserData userData;

    private string savePath;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        savePath = Path.Combine(Application.persistentDataPath, "save.json");

        userData = new UserData("이진영", 200000, 50000);

        //저장된 데이터 불러오기
        if(LoadUserData())
        {
            Debug.Log("UserData Load success from JSON");
        }
    }

    //저장
    public void SaveUserData()
    {
        string json = JsonUtility.ToJson(userData, true);
        File.WriteAllText(savePath, json);
        Debug.Log("Save JSON: " +  json);
    }

    //로드
    public bool LoadUserData()
    {
        if(!File.Exists(savePath))
        {
            return false;
        }

        string json = File.ReadAllText(savePath);
        userData = JsonUtility.FromJson<UserData>(json);
        return true;
    }
}
