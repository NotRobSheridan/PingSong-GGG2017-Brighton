using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour {

    public static int playerOneScore = 0;
    public static int playerTwoScore = 0;
    public Text playerOneText;
    public Text playerTwoText;
    public int maxScore = 10;
    public InputField textEntry;
    Transform ball;
    public Canvas startCanvas;


    // Use this for initialization
    void Start () {
        Time.timeScale = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
    
        playerOneText.text = playerOneScore.ToString();
        playerTwoText.text = playerTwoScore.ToString();
        if (playerOneScore >= maxScore || playerTwoScore >= maxScore)
            Time.timeScale = 0.0f;//TODO: EndGame();
    }

    public void StartGame()
    {
        maxScore = int.Parse(textEntry.text);
        Time.timeScale = 1.0f;
        startCanvas.GetComponent<Canvas>().enabled = false;
    }

    public void UpdatePlayerOneScore()
    {
        playerOneScore++;
    }
    public void UpdatePlayerTwoScore()
    {
        playerTwoScore++;
        Debug.Log("Player 2 Score Updated" + playerTwoScore.ToString());
        StartCoroutine(GetJuicy());

    }

    IEnumerator GetJuicy()
    {
        Time.timeScale = 0.5F;
        yield return new WaitForSeconds(0.08f);
        Time.timeScale = 1.0F;
    }
}
