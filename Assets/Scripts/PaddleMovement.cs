using UnityEngine;
using System.Collections;

public class PaddleMovement : MonoBehaviour {

    public float speed = 5.0f;
    public Transform thisPaddle;
    public bool goLeft = false;
    public float leftMost = -3.5f;
    public float rightMost = 3.5f;

		void Update () {

        if (Input.GetKeyDown("space"))
            goLeft = !goLeft;

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
        if (col.gameObject.name == "Ball")
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }

    }
}
