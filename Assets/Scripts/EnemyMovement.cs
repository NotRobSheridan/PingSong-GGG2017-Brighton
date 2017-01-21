using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{

    public float speed = 5.0f;
    public Transform thisPaddle;
    public bool goLeft = false;
    public GameObject ball;

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {

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
