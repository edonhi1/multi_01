using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;
using SimpleJSON;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class Login : MonoBehaviour {

    public string verCheckURL = "";
    public string gameServerURL = "";
    public GameObject loginBtn;
    public GameObject popupWindow;
    public UILabel logText;

    private void Awake()
    {
        popupWindow.SetActive(false);
    }

    void Start ()
    {
	    if(Application.internetReachability == 0)
        {
            popupWindow.SetActive(true);
            popupWindow.GetComponentInChildren<UILabel>().text = "Could not connect internet..";
            Debug.Log("인터넷 연결 상태를 확인하세요..");
        }
        else
        {
            //여기서 부터 로그인 시작..
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.Activate();

            StartCoroutine(VerCheck());
        }
	}

    IEnumerator VerCheck()
    {
        WWW www = new WWW(verCheckURL);
        yield return www;
        if(www.text == Application.version)
        {
            Debug.Log("버전 정보 일치.");            
        }
        else
        {
            Debug.Log("버전정보가 다릅니다..");
            popupWindow.SetActive(true);
            popupWindow.GetComponentInChildren<UILabel>().text = "Version doesn't matched..";
        }
    }

    IEnumerator StartLogin()
    {
        WWWForm form = new WWWForm();   //클라이언트 데이터를 보내기 위한 새로운 폼 생성
        form.AddField("UserID", PlayerPrefs.GetInt("UserID"));   //생성된 폼에 key, value 추가
        form.AddField("UUID", SystemInfo.deviceUniqueIdentifier);   //생성된 폼에 key, value 추가
        //Debug.Log(PlayerPrefs.GetInt("UserID"));
        //Debug.Log(SystemInfo.deviceUniqueIdentifier);
        WWW www = new WWW(gameServerURL, form);     //http 접속을 위한 새로운 WWW클래스 생성
        yield return www;   //www 반환대기
        Debug.Log(www.text);
        SetMyGameData(www.text);        //www로 반환된 텍스트 setmygamedata인자로 호출
        loginBtn.SetActive(false);
        SceneManager.LoadScene(1);      
    }

    public void SetMyGameData(string data)
    {
        var gameData = JSON.Parse(data);
        PlayerPrefs.SetInt("UserID", int.Parse(gameData["UserID"]));
        PlayerPrefs.SetString("UserNick", gameData["UserNick"]);
#if UNITY_ANDROID && !UNITY_EDITOR
        PlayerPrefs.SetString("Google", Social.localUser.id);
#endif
        PlayerPrefs.SetInt("UserGold", int.Parse(gameData["UserGold"]));
        PlayerPrefs.SetInt("UserCash", int.Parse(gameData["UserCash"]));
        PlayerPrefs.SetInt("UserScore", int.Parse(gameData["UserScore"]));
    }

    public void OpenMarket()
    {
        Application.OpenURL("https://play.google.com");
    }

    public void LoginBtn()
    {
        StartCoroutine(GoogleLogin());
    }

    IEnumerator GoogleLogin()
    {
        yield return null;
#if UNITY_EDITOR
        Debug.Log("Editor 환경입니다.");
        StartCoroutine(StartLogin());
#endif
#if UNITY_ANDROID && !UNITY_EDITOR
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {             
                Debug.Log("로그인 성공!");                //로긴 성공
                logText.text = "Login ID: " + Social.localUser.id;
                StartCoroutine(StartLogin());
            }
            else
            {
                Debug.Log("로그인 실패!");                //로긴 실패
                logText.text = "Login failed!";
            }
        });
#endif
    }
}
