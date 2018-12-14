using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartBtnControl : MonoBehaviour {
    public InputField names;
    public GenderControl Boy;
    public Text warning;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void StartGame()
    {
        string text = names.text;
        if (text == "")
        {
            warning.text = "Pls don't leave this blank";
        }
        else
        {
            PlayerPrefs.SetString("name", text);
            if (Boy.getChosen())
            {
                print(text + " is a Boy");
                PlayerPrefs.SetInt("gender", 1);
            }
            else
            {
                print(text + " is a Girl");
                PlayerPrefs.SetInt("gender", 2);
            }
            PlayerPrefs.SetFloat("x", -3f);
            PlayerPrefs.SetFloat("y", 1f);
            PlayerPrefs.SetInt("stage", 1);
            PlayerPrefs.SetInt("chapter", 1);
            PlayerPrefs.DeleteKey("inventory");
            SceneManager.LoadScene(0);
        }

    }
}
