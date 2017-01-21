using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

	// Use this for initialization
    public void OnPressed()
    {
        SceneManager.LoadScene("MainScreen");
    }
}
