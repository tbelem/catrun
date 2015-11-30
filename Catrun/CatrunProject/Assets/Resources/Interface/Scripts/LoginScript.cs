using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoginScript : MonoBehaviour {

	private string mLogin;
	private string mSenha;
	private InputField inputLogin;
	private InputField inputSenha;

    private DatabaseControl db = new DatabaseControl();


	void Awake() {
		inputLogin = GameObject.Find("InputFieldLogin").GetComponent<InputField>();
		inputSenha = GameObject.Find("SenhaInputField").GetComponent<InputField>();
	}

	public void getValues (){
		mLogin = inputLogin.text;
		mSenha = inputSenha.text;

        GlobalsController.usercode = db.Login(mLogin, mSenha);

        if (GlobalsController.usercode == 1) {
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
