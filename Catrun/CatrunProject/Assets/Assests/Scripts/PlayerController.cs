using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D playerRigidBody;
    public GameObject playerMove;

    public int forceJump;
    public float speed;
    public float alturaMaxima;
    public float alturaMinima;
    

	// Use this for initialization
	void Start () {       
	
	}
	
	// Update is called once per frame
	void Update () {      

        if (Input.GetButtonDown("Jump"))
        {
            playerRigidBody.AddForce(new Vector2(0, forceJump));
        }

        float movimento = Input.GetAxis("Vertical") * speed;
        playerMove.transform.Translate(0, movimento, 0); 
	}
}
