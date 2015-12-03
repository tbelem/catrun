using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainScript : MonoBehaviour {

    DatabaseControl db = new DatabaseControl();

    void Awake()
    {
        GlobalsController.totalmoney = db.getMoney(GlobalsController.usercode);
        GlobalsController.highscore = db.verificaHiscore(GlobalsController.usercode);

        GameObject.Find("HsLabel").GetComponent<Text>().text = "High Score: "+ GlobalsController.highscore;

    }

    public void loadScene(int sceneNum) {
		Application.LoadLevel (sceneNum);
	}	
}