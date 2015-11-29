using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour {

	public void loadScene(int sceneNum) {
		Application.LoadLevel (sceneNum);
	}	
}