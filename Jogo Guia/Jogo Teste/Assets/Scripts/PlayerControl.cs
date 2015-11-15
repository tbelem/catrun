using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    private Vector3 original,atual;
    public float maxima, minima;
    private float control,speed;
    private int pulando = 0;
    private int pontuacao = 0;
    private float scoretime = 0;
    private TextMesh textObject;

    // Use this for initialization
    void Start () {
        original = transform.position;
        speed = 0.15f;
        textObject = GameObject.Find("Score").GetComponent<TextMesh>();
        textObject.text = "0";
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Application.LoadLevelAdditiveAsync("gameover");
    }
	
	// Update is called once per frame
	void Update () {
        scoretime += Time.deltaTime;
        if(scoretime >= 1)
        {
            pontuacao++;
            scoretime = 0;
            TextMesh textObject = GameObject.Find("Score").GetComponent<TextMesh>();
            textObject.text = pontuacao.ToString();
        }
        

        float translation = 0;
        translation = Input.GetAxis("Vertical");
        atual = transform.position;

        if ((atual.y == original.y) && (translation != 0))
        {
            pulando = 1;
        }

        if(pulando == 1)
        {
            if (atual.y + speed > maxima)
            {
                transform.Translate(0, maxima- atual.y, 0);
                pulando = 2;
            }
            else
            {
                transform.Translate(0, speed, 0);
            }
        }

        if (pulando == 2)
        {
            if (atual.y - speed < minima)
            {
                transform.Translate(0, minima - atual.y, 0);
                pulando = 0;
            }
            else
            {
                transform.Translate(0, speed*-1, 0);
            }
        }

    }
}
