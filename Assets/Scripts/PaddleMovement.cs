using UnityEngine;
using System.Collections;

public class PaddleMovement : MonoBehaviour {

    public float speed = 5.0f;
    public Transform thisPaddle;
    public bool goLeft = false;
    public float leftMost = -3.5f;
    public float rightMost = 3.5f;

	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("space"))
            goLeft = !goLeft;

        /*if (thisPaddle.position.x <= leftMost)
            goLeft = !goLeft;

        if (thisPaddle.position.x >= rightMost)
            goLeft = !goLeft;
            */
        if (goLeft)
            thisPaddle.Translate(-Vector2.right * speed * Time.deltaTime);
        else
            thisPaddle.Translate(Vector2.right * speed * Time.deltaTime);

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "LeftWall")
            goLeft = !goLeft;
        if (col.gameObject.name == "RightWall")
            goLeft = !goLeft;

    }


}
