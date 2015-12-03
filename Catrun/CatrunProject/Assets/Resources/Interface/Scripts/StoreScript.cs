using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoreScript : MonoBehaviour {

	StoreElement[] element = new StoreElement[10];
	Text numMoedas;
	Color invisible = new Color(0f, 0f, 0f, 0f);
	Color visible = new Color(1f, 1f, 1f, 1f);

    DatabaseControl db = new DatabaseControl();

	void Awake () {

        numMoedas = GameObject.Find("numMoedas").GetComponent<Text>();

        for (int i=0; i<10; i++) {
            element[i] = new StoreElement();

            element[i].texto = GameObject.Find(("Text" + (i+1))).GetComponent<Text>();
            element[i].imagem = GameObject.Find(("check" + (i+1))).GetComponent<SpriteRenderer>();
            element[i].value = db.getItemValue(i+1);
            element[i].categ = db.getItemCateg(i+1);
        }

        resetSelection ();
	}

	public void resetSelection () {

        db.getPlayerItens(ref element, GlobalsController.usercode);

        for (int i=0; i<10; i++) {

			element[i].imagem.color = invisible;
			
			if (element[i].purchased) {
				element[i].texto.text = "Usar";
			} else {
				element[i].texto.text = element[i].value.ToString(); 
			}
			
			if (element[i].selected)
            {
                element[i].imagem.color = visible;
			}
		}
		numMoedas.text = GlobalsController.totalmoney.ToString();
	}

	public void buyItem (int itemNum) {

		if (GlobalsController.totalmoney >= element[itemNum].value) {
            db.buyItem(itemNum+1, GlobalsController.usercode);
            GlobalsController.totalmoney = db.getMoney(GlobalsController.usercode);
			resetSelection ();
		}

	}

	public void onSelectFirst(int selected){

		if (element[selected].purchased) {
            db.selectItem(selected+1,GlobalsController.usercode, element[selected].categ);
			resetSelection ();
		} else {
			buyItem(selected);
		}
	}
}
