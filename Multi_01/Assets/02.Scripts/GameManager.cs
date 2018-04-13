using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public int gold;
    public int cash;
    public int score;

    public UILabel userNick;
    public UILabel userGold;
    public UILabel userCash;
    public UILabel userScore;

    private void Start()
    {
        gold = PlayerPrefs.GetInt("UserGold");
        cash = PlayerPrefs.GetInt("UserCash");
        score = PlayerPrefs.GetInt("UserScore");        
    }

    private void Update()
    {
        userNick.text = PlayerPrefs.GetString("UserNick");
        userGold.text = "GOLD : " + gold.ToString("#,###,##0");
        userCash.text = "CASH : " + cash.ToString("###,##0"); ;
        userScore.text = "Score : " + score.ToString("#,###,##0"); ;
    }

    public void UpGold()
    {
        gold += 100;
    }

    public void DownGold()
    {
        gold -= 100;
    }

    public void UpCash()
    {
        cash += 10;
    }

    public void DownCash()
    {
        cash -= 10;
    }

    public void UpScore()
    {
        score += 1;
    }

    public void DownScore()
    {
        score -= 1;
    }
}
