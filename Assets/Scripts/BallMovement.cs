using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour
{

    public float speed = 5.0f;
    public float boostSpeed = 10.0f;
    public Rigidbody2D rb;
    public bool gameStarting = false;
    public bool gameStarted = true;
    float visualiserTimer;
    Vector3 previousLoc = Vector3.zero;
    Vector3 currentVelocity;

    void Update()
    {
        visualiserTimer += Time.deltaTime;
        StartGame();
        currentVelocity = (transform.position - previousLoc / Time.deltaTime);
    }

    public void StartGame()
    {
        if (Input.GetKeyDown("space") && gameStarted)
        {
            gameStarting = true;
            gameStarted = false;
        }

        if (gameStarting)
        {
            rb.velocity = Vector2.down * speed;
            gameStarting = false;
        }
    }

    float HitFactor(Vector2 ballPos, Vector2 paddlePos, float paddleWidth)
    {
        Debug.Log("HitFactor Called");
        return (ballPos.x - paddlePos.x) / paddleWidth;
    }

    float WallFactor(Vector2 ballPos, Vector2 wallPos)
    {
        Debug.Log("WallFactor Called");
        return ballPos.x - wallPos.x;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "PaddleBottom")
        {
            Debug.Log("TouchedBottom");
            float x = HitFactor(transform.position, col.transform.position, col.collider.bounds.size.x);
            Vector2 dir = new Vector2(x, 1).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
            speed = speed + 0.2f;
        }
        if (col.gameObject.name == "PaddleTop")
        {
            Debug.Log("TouchedBottom");
            float x = HitFactor(transform.position, col.transform.position, col.collider.bounds.size.x);
            Vector2 dir = new Vector2(x, -1).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
            speed = speed + 0.2f;
        }

        /*if (col.gameObject.name == "LeftWall")
        {
            float x = WallFactor(transform.position, col.transform.position);

            Vector2 dir = new Vector2(x, ).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * boostSpeed;
        }

        if (col.gameObject.name == "RightWall")
        {
            float x = WallFactor(transform.position, col.transform.position);
            Vector2 dir = new Vector2(x, ).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * boostSpeed;
        }*/
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Trigger Entered");
        if (col.gameObject.tag == "Visualiser")
        {

            Debug.Log("Visualiser Hit. Length is: " + col.transform.localScale.y);
            StartCoroutine(VisualiserHit());
            if (currentVelocity.y > 0)
            {
                Debug.Log("GOTTA GO DOWN");
            }
            if (currentVelocity.y < 0)
            {
                Debug.Log("GOTTA GO UP");
            }

        }
    }

    IEnumerator VisualiserHit()
    {
        if(visualiserTimer >= 1)
        {

            Time.timeScale = 0.2F;
            yield return new WaitForSeconds(0.08f);
            Time.timeScale = 1.0F; 
            visualiserTimer = 0;
        }
    }

}