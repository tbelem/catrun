using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AchievementScript : MonoBehaviour {

	achieventElement[] element = new achieventElement[10];
	Text numMoedas;
	Color invisible = new Color(0f, 0f, 0f, 0f);
	Color visible = new Color(1f, 1f, 1f, 1f);
	
	void Awake () {
		Debug.Log ("Awake ()");
		
		for (int i=0; i<10; i++) {
			element[i] = new achieventElement();

			element[i].imagem = GameObject.Find(("check" + (i+1))).GetComponent<SpriteRenderer>();
		}
		getSelectedItens ();
		resetSelection ();
	}
	
	public class achieventElement {
		public Text texto;
		public SpriteRenderer imagem;
		public bool selected;
	}
	
	public void getSelectedItens () {
		Debug.Log ("getSelectedItem ()");
		//codigo par buscar no banco
		element [1].selected = true;
		element [3].selected = true;
		element [5].selected = true;
		element [7].selected = true;
		element [9].selected = true;
	}
	
	public void resetSelection () {
		Debug.Log ("resetSelection ()");
		for (int i=0; i<10; i++) {
			
			element[i].imagem.color = invisible;
			
			if (element[i].selected){
				element[i].imagem.color = visible;
			}
		}
	}

}

