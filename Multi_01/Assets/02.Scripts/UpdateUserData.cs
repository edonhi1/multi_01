using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateUserData : MonoBehaviour {

    public GameManager gameManager;
    public string updateURL = "http://ldh852.cafe24.com/gameserver/update_user.php";

    public void UpdateToServer()
    {
        StartCoroutine(UpdateCoroutine());
    }

    IEnumerator UpdateCoroutine()
    {
        WWWForm form = new WWWForm();
        form.AddField("UserID", PlayerPrefs.GetInt("UserID"));
        form.AddField("UserNick", PlayerPrefs.GetString("UserNick"));
#if UNITY_ANDROID && !UNITY_EDITOR
        form.AddField("Google", PlayerPrefs.GetString("Google"));
#endif
        form.AddField("UserGold", gameManager.gold);
        form.AddField("UserCash", gameManager.cash);
        form.AddField("UserScore", gameManager.score);
        WWW www = new WWW(updateURL, form);
        yield return www;
    }
}
