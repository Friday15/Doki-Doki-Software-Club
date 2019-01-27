using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class TCControl : MonoBehaviour
{
    public GameObject canvas;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void startGame()
    {
        PlayerPrefs.SetFloat("x", -75f);
        PlayerPrefs.SetFloat("y", 16f);
        PlayerPrefs.SetInt("stage", 1);
        PlayerPrefs.SetInt("chapter", 1);
        PlayerPrefs.DeleteKey("inventory");
        PlayerPrefs.SetInt("page", 1);
        SceneManager.LoadScene(13);
    }
    public void hide()
    {
        canvas.SetActive(false);
    }
}
