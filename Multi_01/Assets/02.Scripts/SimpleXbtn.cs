using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleXbtn : MonoBehaviour {
    
    public GameObject thisWindow;

	void Start () {
        thisWindow.SetActive(false);
	}

    public void ClickActivateBtn()
    {
        thisWindow.SetActive(true);
    }

    public void ClickXBtn()
    {
        thisWindow.SetActive(false);
    }
	
	void Update () {
		
	}
}
