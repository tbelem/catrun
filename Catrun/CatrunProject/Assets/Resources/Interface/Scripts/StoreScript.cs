using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoreScript : MonoBehaviour {

	storeElement[] element = new storeElement[10];
	Text numMoedas;
	Color invisible = new Color(0f, 0f, 0f, 0f);
	Color visible = new Color(1f, 1f, 1f, 1f);
	bool[] purchasedItems = new bool[10];
	int selectedItem1 = -1;
	int selectedItem2 = -1;
	int[] itensValues = new int[10];
	int coinCount;
//	GameObject confirmacao;

	void Awake () {
		Debug.Log ("Awake ()");
		getPurchasedElements ();
		getElementsPrice ();
		getSelectedItem ();

		numMoedas = GameObject.Find("numMoedas").GetComponent<Text>();
		getCoins ();

//		confirmacao = GameObject.Find ("Confirmacao").GetComponent<GameObject>();
//		confirmacao.transform.localScale = new Vector3(0, 0, 0);

		for (int i=0; i<10; i++) {
			element[i] = new storeElement();

			element[i].texto = GameObject.Find(("Text" + (i+1))).GetComponent<Text>();
			element[i].imagem = GameObject.Find(("check" + (i+1))).GetComponent<SpriteRenderer>();
		}
		resetSelection ();
	}

	public class storeElement {
		public Text texto;
		public SpriteRenderer imagem;
	}

	public void getPurchasedElements () {
		Debug.Log ("getPurchasedElements ()");
//		for (int i=0; i<10; i++) {
//			purchasedItems[i] = ????
//		}

		for (int i=0; i<10; i++) {
			purchasedItems[i] = false;
		}

		purchasedItems [0] = true;
		purchasedItems [3] = true;
		purchasedItems [6] = true;
		purchasedItems [9] = true;
	}

	public void getElementsPrice () {
		Debug.Log ("getElementsPrice ()");
		//		for (int i=0; i<10; i++) {
		//			itensValues[i] = ????
		//		}
		
		for (int i=0; i<10; i++) {
			itensValues[i] = 1000;
		}
		
		itensValues [1] = 1200;
		itensValues [4] = 1400;
		itensValues [7] = 3000;
		itensValues [9] = 8000;
	}

	public void getSelectedItem(){
		Debug.Log ("getSelectedItem ()");
//		selectedItem1 = ???;
		selectedItem1 = 2;

//		selectedItem2 = ????;
		selectedItem2 = 5; 
	}

	public void resetSelection () {
		Debug.Log ("resetSelection ()");
		for (int i=0; i<10; i++) {

			element[i].imagem.color = invisible;
			
			if (purchasedItems[i]) {
				element[i].texto.text = "Usar";
			} else {
				element[i].texto.text = "$" + itensValues[i]; 
			}
			
			if (i == selectedItem1 || i == selectedItem2){
				element[i].imagem.color = visible;
			}
		}
		numMoedas.text = "Moedas $" + coinCount;
	}

	public void buyItem (int itemNum) {
		Debug.Log ("buyItem (" + itemNum +")");
		//codigo para gerenciar o dinheiro
		//codigo para mudar o banco

		if (coinCount >= itensValues [itemNum]) {
			purchasedItems [itemNum] = true;
			coinCount -= itensValues [itemNum];
			resetSelection ();
		}

	}

	public void onSelectFirst(int selected){
		Debug.Log ("onSelectFirst(" + selected +")");
		if (purchasedItems [selected]) {
			selectedItem1 = selected;
			resetSelection ();
		} else {
			buyItem(selected);
		}
	}

	public void onSelectSecond(int selected){
		Debug.Log ("onSelectSecond(" + selected + ")");
		if (purchasedItems [selected]) {
			selectedItem2 = selected;
			resetSelection ();
		} else {
			buyItem(selected);
		}
	}

	public void getCoins(){
		//Codigo para pegar as moedas do banco
		coinCount = 2000;
	}
}
