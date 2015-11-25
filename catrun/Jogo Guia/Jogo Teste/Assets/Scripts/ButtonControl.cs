using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour {

    public void OnClick()
    {
        InputField login = GameObject.Find("Login").GetComponent<InputField>();
        InputField pass = GameObject.Find("Password").GetComponent<InputField>();

        if ((login.text != "") && (pass.text != ""))
        {
            DatabaseControl db = new DatabaseControl();
            Debug.Log("RESULTADO: " + db.Login(login.text, pass.text));
        }
    }

}
