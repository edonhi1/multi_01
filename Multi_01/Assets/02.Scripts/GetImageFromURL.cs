using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetImageFromURL : MonoBehaviour {

    public string url = "http://images.earthcam.com/ec_metros/ourcams/fridays.jpg";

    void Start ()
    {
        Debug.Log(Application.internetReachability);
        StartCoroutine(GetImage());
    }

    IEnumerator GetImage()
    {
        WWW www = new WWW(url);
        yield return www;
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = www.texture;
    }

    void Update ()
    {
     
    }
}
