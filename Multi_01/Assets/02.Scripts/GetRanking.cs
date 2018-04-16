using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;
using SimpleJSON;

public class GetRanking : MonoBehaviour {

    public string rankURL = "http://ldh852.cafe24.com/gameserver/get_ranking.php";

    IEnumerator GetRank()
    {
        WWW www = new WWW(rankURL);
        yield return www;
        var data = JSON.Parse(www.text);
        for (int i = 0; i < data.Count; i++)
        {
            GetComponent<GridContentsManager>().MakeContents
                (
                data[i]["UserNick"], data[i]["UserPic"], data[i]["UserScore"], i
                );
            GetComponent<UIGrid>().enabled = true;
            //Debug.Log(data[i]["UserNick"]);     
            //Debug.Log(data[i]["UserScore"]);
            //배열의 순서와 키값으로 데이터를 가져오고 있다.
        }
    }

    void Start () {
        StartCoroutine(GetRank());
	}
}
