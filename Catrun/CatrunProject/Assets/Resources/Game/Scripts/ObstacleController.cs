using UnityEngine;
using System.Collections;

public class ObstacleController : MonoBehaviour {

    public float speed;

    private float quantidade;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        quantidade = speed * Time.deltaTime;

         transform.Translate(quantidade*-1,0,0);

        if(transform.position.x <= -15)
        {
            Destroy(gameObject);
        }

    }
}
