using UnityEngine;
using System.Collections;

public class SpawnObject : MonoBehaviour {

    public float ratePerSec;
    private float currRateTime = 0;
    
    // Use this for initialization
	void Start () {
	  
	}

    void Update() {
        currRateTime += Time.deltaTime;

        if (currRateTime >= ratePerSec)
        {
            Spawn();
            currRateTime = 0;
        }

    }
	
	// Update is called once per frame
	private void Spawn() {
        int tipo = 1;// Random.Range(1,3);

        if (tipo == 1) //toy
        {
            GameObject temp = Instantiate(Resources.Load("Prefabs/ToyCar")) as GameObject;
            temp.transform.position = new Vector3(transform.position.x, -3.6f,transform.position.z);
        }
        if (tipo == 2)//police
        {
            GameObject temp = Instantiate(Resources.Load("Prefabs/PoliceCar")) as GameObject;
            temp.transform.position = new Vector3(transform.position.x, -1.71f, transform.position.z);
        }

    }
}
