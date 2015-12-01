using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {

    public float velocidadeCenario;

    private Material fundo;
    private float offset;

	// Use this for initialization
	void Start () {

        fundo = gameObject.GetComponent<Renderer>().material; 
	}
	
	// Update is called once per frame
	void Update () {

        offset += velocidadeCenario * Time.deltaTime;
        fundo.SetTextureOffset("_MainTex", new Vector2(offset, 0));
	
	}
}
