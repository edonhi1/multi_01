using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckNickName : MonoBehaviour {

    public GameObject popUpWindow;
    public UpdateUserData updateData;
    public UILabel inputText;

	void Start () {
		if(PlayerPrefs.GetString("UserNick")== "NewName")
        {
            popUpWindow.SetActive(true);
        }
	}

    public void SetUserNick()
    {
        PlayerPrefs.SetString("UserNick", inputText.text);
        updateData.UpdateToServer();
        popUpWindow.SetActive(false);
    }

    public void ChangeNickname()
    {
        popUpWindow.SetActive(true);
    }

    public void CloseWindow()
    {
        popUpWindow.SetActive(false);
    }
}
