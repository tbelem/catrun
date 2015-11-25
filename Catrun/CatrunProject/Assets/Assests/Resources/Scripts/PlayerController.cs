using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
      
    public float velocidade;    
    public float faixaCima;
    public float faixaBaixo;
    public float faixaMeio;
    public float velocidadeFaixa;

    private float alturaMaxima;
    private float alturaMinima;
    private int controlePulo;
    private float controleFaixa;
    

	// Use this for initialization
	void Start () {

        this.controlePulo = 0;	
	}
	
	// Update is called once per frame
	void Update () {        

        if (Input.GetButton("Jump"))
        {
            if (controlePulo == 0)
            {
                controlePulo = 1;
                alturaMinima = transform.position.y;
                alturaMaxima = alturaMinima + 1.2f;
            }
        }

        Pulo();


        controleFaixa += Time.deltaTime;

        if (Input.GetAxis("Vertical") > 0)
        {
            trocaFaixa(1);
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            trocaFaixa(-1);
        }

	}

    void Pulo()
    {
        float quantidade;

        if(controlePulo==1)
        {
            quantidade = velocidade*Time.deltaTime;
            transform.Translate(0, quantidade, 0);

            if(transform.position.y >= alturaMaxima)
            {
                controlePulo = 2;
                transform.position = new Vector3(transform.position.x, alturaMaxima, transform.position.z);
            }
        }

        if (controlePulo == 2)
        {
            quantidade = (velocidade * Time.deltaTime)*-1;
            transform.Translate(0, quantidade, 0);

            if (transform.position.y <= alturaMinima)
            {
                controlePulo = 0;
                transform.position = new Vector3(transform.position.x, alturaMinima, transform.position.z);
            }
        }
    }

    void trocaFaixa(int sentidoFaixa)
    {
        if (controleFaixa >= velocidadeFaixa)
        {

            if (sentidoFaixa > 0)
            {

                if (transform.position.y == faixaMeio)
                {
                    transform.position = new Vector3(transform.position.x, faixaCima, transform.position.z);
                }

                if (transform.position.y == faixaBaixo)
                {
                    transform.position = new Vector3(transform.position.x, faixaMeio, transform.position.z);
                }
            }

            if (sentidoFaixa < 0)
            {
                if (transform.position.y == faixaMeio)
                {
                    transform.position = new Vector3(transform.position.x, faixaBaixo, transform.position.z);
                }

                if (transform.position.y == faixaCima)
                {
                    transform.position = new Vector3(transform.position.x, faixaMeio, transform.position.z);
                }
            }

            controleFaixa = 0;
        }
    }
}
