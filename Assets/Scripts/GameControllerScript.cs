using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour {

    public static int playerOneScore = 0;
    public static int playerTwoScore = 0;
    public Text playerOneText;
    public Text playerTwoText;
    Transform ball;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
    
                playerOneText.text = playerOneScore.ToString();
                playerTwoText.text = playerTwoScore.ToString();
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
