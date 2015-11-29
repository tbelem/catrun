using UnityEngine;
using System.Collections;

public class SpawnerController : MonoBehaviour {

    public float speed;

    private float timecontrol;
    private DatabaseControl db;

    // Use this for initialization
    void Start () {
        db = new DatabaseControl();
	
	}
	
	// Update is called once per frame
	void Update () {
        timecontrol += Time.deltaTime;

        if(timecontrol >= speed)
        {
            string prefab = "";
            float posy = 0;
            float posz = 0;
                
            db.getObstaculo(ref prefab,ref posy,ref posz);

            GameObject temp = Instantiate(Resources.Load("Game/Prefabs/"+prefab)) as GameObject;
            temp.transform.position = new Vector3(temp.transform.position.x, posy, posz);

            timecontrol = 0;
        }



    }
}
