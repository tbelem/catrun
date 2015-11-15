using UnityEngine;
using System.Collections;

public class ObjectControl : MonoBehaviour {

    public float speed;

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position -= new Vector3(speed,0,0) * Time.deltaTime;

        if(transform.position.x <= -13)
        {
            Destroy(gameObject);
        }
	
	}
}
