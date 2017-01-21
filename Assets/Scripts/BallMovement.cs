using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BallMovement : MonoBehaviour
{

    public float speed = 5.0f;
    public float boostSpeed = 10.0f;
    public Rigidbody2D rb;
    public GameObject gameControllerScript;
    public static int playerOneScore;
    public static int playerTwoScore;
    public Color initialColor;
    public Color secondColor;
    public bool switchColor;
    public Renderer rend;
    


    Vector3 previousLoc = Vector3.zero;
    Vector3 currentVelocity;
    bool gameStarting = false;
    bool gameStarted = true;
    float visualiserTimer;

    void Start()
    {

    }

    void Update()
    {
        visualiserTimer += Time.deltaTime;
        StartGame();
        currentVelocity = (transform.position - previousLoc / Time.deltaTime);

        if (speed >= 10)
            speed = 10;

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

        if (col.gameObject.name == "BottomWall")
        {
            gameControllerScript.GetComponent<GameControllerScript>().UpdatePlayerTwoScore();
            Debug.Log("Bottom Wall Hit");
        }
        if (col.gameObject.name == "TopWall")
        {
            gameControllerScript.GetComponent<GameControllerScript>().UpdatePlayerOneScore();
            Debug.Log("Top Wall Hit");
        }

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
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {

        Debug.Log("Trigger Entered");
        if (visualiserTimer >= 1)
        {
            if (col.gameObject.tag == "Visualiser")
            {
                rend = col.GetComponent<MeshRenderer>();
                if (switchColor)
                {
                    rend.material.color = secondColor;
                    switchColor = !switchColor;
                }else if(switchColor == false)
                {
                    rend.material.color = initialColor;
                    switchColor = !switchColor;
                }


                Debug.Log("Visualiser Hit. Length is: " + col.transform.localScale.y);
                StartCoroutine(VisualiserHit(col));
                if (currentVelocity.y > 0)
                {
                    Debug.Log("GOTTA GO DOWN");
                    Vector2 dir = new Vector2(0, -1).normalized;
                    GetComponent<Rigidbody2D>().velocity = dir * speed * (col.transform.localScale.y * 2f);



                }
                if (currentVelocity.y < 0)
                {
                    Debug.Log("GOTTA GO UP");
                    Vector2 dir = new Vector2(0, 1).normalized;
                    GetComponent<Rigidbody2D>().velocity = dir * speed * (col.transform.localScale.y * 1.5f );

                }
                visualiserTimer = 0;

            }
        }


        if (col.gameObject.name == "BottomWall")
        {
            Debug.Log("Visualiser Hit. Length is: " + col.transform.localScale.y);
            //StartCoroutine(VisualiserHit());
        }
    }

    IEnumerator VisualiserHit(Collider2D col)
    {
        if(visualiserTimer >= 1)
        {

            Time.timeScale = 0.3F;
            yield return new WaitForSeconds(0.08f);
            Time.timeScale = 1.0F; 
            visualiserTimer = 0;
        }
    }

}