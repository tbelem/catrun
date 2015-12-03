using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameoverScript : MonoBehaviour {

	Text numMoedas;
	Text pontos;

    private DatabaseControl db = new DatabaseControl();

	void Awake () {
		numMoedas = GameObject.Find("TextMoedas").GetComponent<Text>();
		pontos = GameObject.Find("TextPontos").GetComponent<Text>();
        numMoedas.text = GlobalsController.money.ToString();
		pontos.text = GlobalsController.score.ToString();

        int hs = 0;
        if (GlobalsController.score > db.verificaHiscore(GlobalsController.usercode))
        {
            GlobalsController.highscore = GlobalsController.score;
            hs = 1;
        }
        else
        {
            hs = 0;
        }

        db.gravaPartida(GlobalsController.usercode
                       , hs
                       , GlobalsController.money
                       , GlobalsController.score
                       , GlobalsController.obstacles
                       , GlobalsController.powerups
                       , GlobalsController.missions);
    }
}
