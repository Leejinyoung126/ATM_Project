using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public UserData userData;

    

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
        userData = new UserData("이진영", 200000, 50000);

        //저장된 데이터 불러오기
        if(LoadUserData())
        {
            Debug.Log("UserData Load success");
        }
    }

    //저장
    public void SaveUserData()
    {
        PlayerPrefs.SetString("user_name", userData.name);
        PlayerPrefs.SetInt("user_cash", userData.cash);
        PlayerPrefs.SetInt("user_balance", userData.balance);
        PlayerPrefs.Save();
    }

    //로드
    public bool LoadUserData()
    {
        if(!PlayerPrefs.HasKey("user_name"))
        {
            return false;
        }

        userData.name = PlayerPrefs.GetString("user_name");
        userData.cash = PlayerPrefs.GetInt("user_cash");
        userData.balance = PlayerPrefs.GetInt("user_balance");
        return true;
    }
}
