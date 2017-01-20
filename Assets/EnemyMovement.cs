using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{

    public float speed = 5.0f;
    public Transform thisPaddle;
    public bool goLeft = false;
    public float leftMost = -3.7f;
    public float rightMost = 4;
    //float randomNumber;
    public GameObject ball;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

       // Vector2 newPosition = ball.transform.localPosition;

       // newPosition.x = Mathf.Lerp(transform.localPosition.x, ball.transform.localPosition.x, Time.deltaTime);

        //transform.localPosition = newPosition;


        //transform.position = Vector2.MoveTowards(transform.position, ball.transform.position, speed * Time.deltaTime);

        if (goLeft)
            thisPaddle.Translate(-Vector2.right * speed * Time.deltaTime);
        else
            thisPaddle.Translate(Vector2.right * speed * Time.deltaTime);

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
