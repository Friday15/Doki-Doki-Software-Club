using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartBtnControl : MonoBehaviour {
    public InputField names;
    public GenderControl Boy;
    public Text warning;
    public GameObject canvas;
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
            warning.text = "Please don't leave this blank";
        }else if (text.Length>10)
        {
            warning.text = "Please keep it less than 10 character";
        }
        else
        {
            warning.text = "";
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
            canvas.SetActive(true);

        }

    }
}
