using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameoverScript : MonoBehaviour {

	Text numMoedas;
	Text pontos;

	void Awake () {
		numMoedas = GameObject.Find("TextMoedas").GetComponent<Text>();
		pontos = GameObject.Find("TextPontos").GetComponent<Text>();
		numMoedas.text = "$" + getMoedas ().ToString ();
		pontos.text = getPontos ().ToString ();
	}

	public int getMoedas (){
		//codigo para buscar do banco
		return 500;
	}

	public int getPontos (){
		//codigo para buscar do banco
		return 10000;
	}
}
