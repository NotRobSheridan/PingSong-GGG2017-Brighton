using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BallMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float boostSpeed = 10.0f;
    public Rigidbody2D rb;
    public GameObject gameControllerScript;
    public GameObject cameraScript;
    public static int playerOneScore;
    public static int playerTwoScore;
    public Color initialColor;
    public Color secondColor;
    public bool switchColor;
    public Renderer rend;
    public Color initialBallColor;
    public Color ballHitColor;
    public GameObject mainLight;

    Vector3 previousLoc = Vector3.zero;
    Vector3 currentVelocity;
    bool gameStarting = false;
    bool gameStarted = true;
    float visualiserTimer;
    GameObject juice;
    Vector3 initialPos;

    //Audio Soures

    float maxFlickerSpeed = 0.1f;
    float minFlickerSpeed = 1.0f;

    void Update()
    {
        visualiserTimer += Time.deltaTime;
        StartGame();
        currentVelocity = (transform.position - previousLoc / Time.deltaTime);
        Vector3 originalPosition = gameObject.transform.position;

        if (gameObject.transform.position.x >= 10 || gameObject.transform.position.x <= -10 || gameObject.transform.position.y >= 10 || gameObject.transform.position.y <= -10)
        {
            Debug.Log("Oops, ball ran away");
            gameObject.transform.position = new Vector3(0, 0, 0);
        }

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

        if (col.gameObject.tag == "Wall")
        {
           col.gameObject.GetComponent<VerticalWallJuice>().GetJuicy();
        }



    }

    void OnTriggerEnter2D(Collider2D col)
    {

        Debug.Log("Trigger Entered");
        if (visualiserTimer >= 1)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();

            if (col.gameObject.tag == "Visualiser")
            {
                int randomNum;
                randomNum = Random.Range(0, 10);
                if (randomNum <= 2)
                    StartCoroutine(FlickerLights());

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
            var shake = cameraScript.GetComponent<CameraShake>();
            shake.shakeDuration = 0.5f;
            Time.timeScale = 1.0F; 
            visualiserTimer = 0;
        }
    }

    IEnumerator FlickerLights()
    {
        Light flickerLight;
        flickerLight = mainLight.GetComponent<Light>();
        flickerLight.enabled = false;
        yield return new WaitForSeconds (Random.Range(minFlickerSpeed, maxFlickerSpeed));
        flickerLight.enabled = true;
        yield return new WaitForSeconds (Random.Range(minFlickerSpeed, maxFlickerSpeed));

    }
}