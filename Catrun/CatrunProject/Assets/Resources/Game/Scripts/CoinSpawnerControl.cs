using UnityEngine;
using System.Collections;

public class CoinSpawnerControl : MonoBehaviour {

    public float speed;

    private float timecontrol;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timecontrol += Time.deltaTime;

        if (timecontrol >= speed)
        {
            float posy = 0;
            float posz = 0;
            int lane = Random.Range(1, 4);

            if (lane == 1) // BOT
            {
                posy = -4.03f;
                posz = -1;
            }
            if (lane == 2) // MID
            {
                posy = -2.4f;
                posz = 0;
            }
            if (lane == 3) // TOP
            {
                posy = -1.06f;
                posz = 1;
            }


            GameObject temp = Instantiate(Resources.Load("Game/Prefabs/COIN")) as GameObject;
            temp.transform.position = new Vector3(temp.transform.position.x, posy, posz);

            timecontrol = 0;
        }

    }
}
