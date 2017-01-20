using UnityEngine;
using System.Collections;

public class PaddleMovement : MonoBehaviour {

    public float speed = 5.0f;
    public Transform thisPaddle;
    public bool goLeft = false;
    public float leftMost = -3.7f;
    public float rightMost = 4;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (goLeft)
            thisPaddle.Translate(-Vector2.right * speed * Time.deltaTime);
        else
            thisPaddle.Translate(Vector2.right * speed * Time.deltaTime);

        if (Input.GetKeyDown("space"))
            goLeft = !goLeft;

        if (thisPaddle.position.x <= leftMost)
            goLeft = !goLeft;

        if (thisPaddle.position.x >= rightMost)
            goLeft = !goLeft;


        // Debug.Log(transform.position.x);

        /*if(Input.GetKeyDown("space"))
        {
            Debug.Log("Space is down");
            if(thisPaddle.position.x >= -3.71)
                thisPaddle.Translate(Vector2.right * speed * Time.deltaTime);
             //else if(transform.position.x <= 10)
               // transform.Translate(-Vector2.right * speed * Time.deltaTime);
        }*/

    }

}
