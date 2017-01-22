using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour {

    public static int playerOneScore = 0;
    public static int playerTwoScore = 0;
    public Text playerOneText;
    public Text playerTwoText;
    public int maxScore = 10;
    public InputField textEntry;
    Transform ball;
    public Canvas startCanvas;
    public Canvas endCanvas;
    public Text winnerText;
    public Light mainLight, visualiserLight;
    public AudioClip score;
    public AudioClip win;
    public AudioSource audio;
    public bool gameFinished = false;
    public bool playWinSound;

    // Use this for initialization
    void Start () {
        Time.timeScale = 0.0f;
        endCanvas.GetComponent<Canvas>().enabled = false;
        playerOneScore = 0;
        playerTwoScore = 0;
        visualiserLight.GetComponent<Light>().enabled = false;
        mainLight.GetComponent<Light>().enabled = false;
        AudioSource audio = GetComponent<AudioSource>();
        gameFinished = false;
        playWinSound = true;
    }

    // Update is called once per frame
    void Update () {
    
        playerOneText.text = playerOneScore.ToString();
        playerTwoText.text = playerTwoScore.ToString();
        WinGame();

    }

    public void StartGame()
    {
        maxScore = int.Parse(textEntry.text);
        Time.timeScale = 1.0f;
        startCanvas.GetComponent<Canvas>().enabled = false;
        visualiserLight.GetComponent<Light>().enabled = true;
        mainLight.GetComponent<Light>().enabled = true;

    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainScreen");
        }


    public void UpdatePlayerOneScore()
    {
        if (gameFinished == false)
        {
            playerOneScore++;
            audio.pitch = (Random.Range(0.6f, 1.5f));
            audio.PlayOneShot(score);
            StartCoroutine(GetJuicy());
        }

    }
    public void UpdatePlayerTwoScore()
    {
        if (gameFinished == false)
        {
            playerTwoScore++;
            audio.pitch = (Random.Range(0.6f, 1.5f));
            audio.PlayOneShot(score);
            StartCoroutine(GetJuicy());
        }

    }

    public void WinGame()
    {
        playerOneText.text = playerOneScore.ToString();
        playerTwoText.text = playerTwoScore.ToString();

        if (playerOneScore >= maxScore || playerTwoScore >= maxScore)
        {
            gameFinished = true;

            Time.timeScale = 0.0f;//TODO: EndGame();
            visualiserLight.GetComponent<Light>().enabled = false;
            mainLight.GetComponent<Light>().enabled = false;
            endCanvas.GetComponent<Canvas>().enabled = true;
            if (playWinSound)
            {
                audio.pitch = Random.Range(0.9f, 1.1f);
                audio.PlayOneShot(win);
            }
            playWinSound = false;
            if (playerOneScore > playerTwoScore)
                winnerText.text = "Player 1 Wins";
            else
                winnerText.text = "Player 2 Wins";
        }

    }


    public void EndGame()
    {
        Application.Quit();
    }

    IEnumerator GetJuicy()
    {
        Time.timeScale = 0.5F;
        yield return new WaitForSeconds(0.08f);
        Time.timeScale = 1.0F;
    }
}
