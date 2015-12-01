using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {

    // Use this for initialization
    public float speed;

    private float quantidade;
    private float lastx;
    private float timecontrol;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        timecontrol += Time.deltaTime;
        if (timecontrol >= 0.2f)
        {
            //ANIMATION
            if (transform.localScale.x == 0.1f)
            {
                transform.localScale = new Vector3(0.2f, transform.localScale.y, transform.localScale.z);
                lastx = 0.1f;
            }
            else
            {
                if (transform.localScale.x == 0.2f)
                {
                    if (lastx == 0.1f)
                    {
                        transform.localScale = new Vector3(0.3f, transform.localScale.y, transform.localScale.z);
                    }
                    else
                    {
                        transform.localScale = new Vector3(0.1f, transform.localScale.y, transform.localScale.z);
                    }

                    lastx = 0.2f;
                }
                else
                {
                    if (transform.localScale.x == 0.3f)
                    {
                        transform.localScale = new Vector3(0.2f, transform.localScale.y, transform.localScale.z);
                        lastx = 0.3f;
                    }
                }
            }

            timecontrol = 0;
        }


        // MOVIMENTO
        quantidade = speed * Time.deltaTime;

        transform.Translate(quantidade * -1, 0, 0);

        if (transform.position.x <= -15)
        {
            Destroy(gameObject);
        }

    }
}
