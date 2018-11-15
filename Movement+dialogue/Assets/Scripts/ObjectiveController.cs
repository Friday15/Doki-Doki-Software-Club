using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveController : MonoBehaviour {
    public Text UItext;
    public Text PastText;
    public Text CurrentText;
    // Use this for initialization
    public string CurrentO;
    
    public void MissionComplete(int Chapter,int task)
    {
        if (Chapter == 1 && task == 1)
        {
            CurrentO= "Give Books to Girl (Press enter twice near her)";
            addPast(UItext.text,CurrentO);
            UItext.text = CurrentO;
            task++;
        }else if(Chapter ==1 && task == 2)
        {
            CurrentO = "Wait for future updates";
            addPast(UItext.text, CurrentO);
            UItext.text = CurrentO;
            task++;
        }
            
    }
    
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void addPast(string past,string s)
    {
        PastText.text = PastText.text + "\n>" + past;
        CurrentText.text = "Current Objective:\n" + s;
    }
}
