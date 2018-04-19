using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetUserImage : MonoBehaviour {

    public string url = "http://ldh852.cafe24.com/userpics/bt.png";
    public Texture basicPic;

    void Start () {
        StartCoroutine(GetImage());
    }

    IEnumerator GetImage()
    {
        WWW www = new WWW(url);
        yield return www;
        UITexture texture = GetComponent<UITexture>();
        texture.mainTexture = www.texture;
    }
}
