using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoginScript : MonoBehaviour {

	private string mLogin;
	private string mSenha;
	private InputField inputLogin;
	private InputField inputSenha;


	void Awake() {
		inputLogin = GameObject.Find("InputFieldLogin").GetComponent<InputField>();
		inputSenha = GameObject.Find("SenhaInputField").GetComponent<InputField>();
	}

	bool validateLogin(string login, string senha) {
		if (login == "abcd" && senha == "1234") {
			return true;
		}
		return false;
	}

	public void getValues (){
		mLogin = inputLogin.text;
		mSenha = inputSenha.text;

		if (validateLogin (mLogin, mSenha) == true) {
			Debug.Log ("Login e senha corretos");
			Application.LoadLevel("mainScreen");
		} else {
			Debug.Log ("Login e senhas invalidos");
		}
	}

	public void closeGame (){
		Application.Quit();
	}
}
