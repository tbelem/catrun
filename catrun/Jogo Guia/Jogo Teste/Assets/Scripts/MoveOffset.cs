using UnityEngine;
using System.Collections;

public class MoveOffset : MonoBehaviour {

    private Material fundo;
    public float speed;
    private float offset;

    // Use this for initialization
    void Start() {

        fundo = gameObject.GetComponent<Renderer>().material;

    }

    // Update is called once per frame
    void Update() {
        offset += Time.deltaTime;
        fundo.SetTextureOffset("_MainTex", new Vector2(offset * speed, 0));
    }
}