using UnityEngine;
using System.Collections;

public class GameOverControl : MonoBehaviour {

    private float currTime;
    
    // Use this for initialization
	void Start () {
        currTime = Time.timeScale;
        Time.timeScale = 0;

    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Fire1"))
        {
            Time.timeScale = currTime;
            Application.LoadLevel("scene");
        }
	
	}
}
