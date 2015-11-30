using UnityEngine;
using System.Collections;

public class GameOverControl : MonoBehaviour {

    private DatabaseControl db = new DatabaseControl();
    
    // Use this for initialization
	void Start () {

        int hs = db.verificaHiscore(GlobalsController.usercode,GlobalsController.score);
        db.gravaPartida(GlobalsController.usercode,hs,0,GlobalsController.score,0,0,0);

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire"))
        {
            Application.LoadLevel(5);
        }
	
	}
}
