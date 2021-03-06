﻿using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour {
      
    public float velocidade;    
    public float faixaCima;
    public float faixaBaixo;
    public float faixaMeio;
    public float velocidadeFaixa;

    private float alturaMaxima;
    private float alturaMinima;
    private int controlePulo;

    private float controleScoreTime;
    private int   score;
    private TextMesh score_txt;

    private float ztop = 1;
    private float zmid = 0;
    private float zbot = -1;


    // Use this for initialization
    void Start () {

        this.controlePulo = 0;
        score_txt = GameObject.Find("Score").GetComponent<TextMesh>();

    }
	
	// Update is called once per frame
	void Update () {

        //CONTROLE DO PULO
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

        //CONTROLE MUDANCA DE FAIXA
        if (Input.GetKeyDown("up"))
        {
            trocaFaixa(1);
        }

        if (Input.GetKeyDown("down"))
        {
            trocaFaixa(-1);
        }

        //CONTROLE SCORE
        float tempscore = 50 * Time.deltaTime;
        score += Convert.ToInt32(tempscore);            
        score_txt.text = score.ToString();

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
        if (sentidoFaixa > 0)
        {

            if (transform.position.y == faixaMeio)
            {
                transform.position = new Vector3(transform.position.x, faixaCima, ztop);
            }

            if (transform.position.y == faixaBaixo)
            {
                transform.position = new Vector3(transform.position.x, faixaMeio, zmid);
            }
        }

        if (sentidoFaixa < 0)
        {
            if (transform.position.y == faixaMeio)
            {
                transform.position = new Vector3(transform.position.x, faixaBaixo, zbot);
            }

            if (transform.position.y == faixaCima)
            {
                transform.position = new Vector3(transform.position.x, faixaMeio, zmid);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Time.timeScale = 0;

    }
}
