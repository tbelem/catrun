using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MissionScript : MonoBehaviour {

	private string missionText;
	private Text textBox;

	void Awake () {
		GameObject.Find("textoMissao").GetComponent<Text>().text = getTextFromDataBase();
	}

	public string getTextFromDataBase () {
		return "Salte 20 veículos em um único jogo.";
	}
}
