using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveController : MonoBehaviour {
    public Text UItext;
    public Text PastText;
    public Text CurrentText;
    public AudioController Sound;
    // Use this for initialization
    public string CurrentO;
    public int CChapter;
    public int Ctask;
    public void MissionComplete(int Chapter,int task)
    {
        if (Chapter == 1 && task == 1&&CChapter==1&&Ctask==1)
        {
            //CurrentO= "Give Books to Girl (Press enter twice near her)";
            //addPast(UItext.text,CurrentO);
            //UItext.text = CurrentO;
            //Ctask++;
            UpdateChapter("Give Books to Girl (Press enter twice near her)");
        }else if(Chapter ==1 && task == 2&& CChapter == 1 && Ctask == 2)
        {
            //CurrentO = "Wait for future updates";
            //addPast(UItext.text, CurrentO);
            //UItext.text = CurrentO;
            //Ctask++;
            UpdateChapter("Wait for future updates");
        }
            
    }
    
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void UpdateChapter(string chapname){
        CurrentO = chapname;
        addPast(UItext.text, CurrentO);
        UItext.text = CurrentO;
        Ctask++;
        Sound.PlaySound();
    }
    public void addPast(string past,string s)
    {
        PastText.text = PastText.text + "\n>" + past;
        CurrentText.text = "Current Objective:\n" + s;
    }
}
