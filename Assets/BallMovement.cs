using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {

   // public Rigidbody2D ballBody;
    public float speed = 5.0f;
    public float sineYpos;
    //public GameObject sineWave;
    public SineWave sineWaveScript;
    public Rigidbody2D rb;
    public bool gameStarting = false;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();
        GameObject waveVisualiser = GameObject.Find("WaveVisualiser");
        sineWaveScript = waveVisualiser.GetComponent<SineWave>();
    }

    // Update is called once per frame
    void Update () {

        if(Input.GetKeyDown("space"))
        {
            gameStarting = true;

        }

        if(gameStarting)
           rb.velocity = Vector2.down * speed;
           gameStarting = false;   

        sineYpos = sineWaveScript.yPos;

       /* if (sineYpos < 0)
           rb.AddForce(transform.x);
        else
//rb.AddForce();*/
    }
}
