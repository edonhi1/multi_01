using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridContentsManager : MonoBehaviour {

    public GameObject contents;
    public int lmt;


	void Start () {
        //MakeContents(lmt);
	}

    public void MakeContents(string name, string picURL, int score, int i)
    {
        GameObject obj = Instantiate(contents) as GameObject;
        obj.name = "Contents" + i;
        obj.transform.parent = gameObject.transform;
        obj.transform.localScale = new Vector3(1, 1, 1);        //부모 크기에 비례하게 보정
        obj.GetComponent<RankContents>().rankNum.text = (i + 1).ToString();
        obj.GetComponentInChildren<GetUserImage>().url = picURL;
        obj.GetComponent<RankContents>().userName.text = name;
        obj.GetComponent<RankContents>().userScore.text = score.ToString();
    }
}
