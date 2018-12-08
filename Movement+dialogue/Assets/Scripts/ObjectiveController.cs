using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveController : MonoBehaviour {
    
    public Text PastText;
    public Text CurrentText;
    public AudioController Sound;
    // Use this for initialization
    public string CurrentO;
    public int CChapter;
    public int Ctask;

    //public GameObject UObjective;
    //public GameObject Cur;
    bool[] c1done;
    List<string> c1 = new List<string>();
    public Sprite check;
    public Sprite NonCheck;
    public Image one;
    public Image two;
    public Image three;


    public void MissionComplete(int Chapter,int task)
    {
        if (Chapter == 1 && task == 1&&CChapter==1&&Ctask==1)
        {
            //CurrentO= "Give Books to Girl (Press enter twice near her)";
            //addPast(UItext.text,CurrentO);
            //UItext.text = CurrentO;
            //Ctask++;
            UpdateChapter("Give Books to Girl (Press enter twice near her)");
            one.sprite = NonCheck;
        }else if(Chapter ==1 && task == 2&& CChapter == 1 && Ctask == 2)
        {
            //CurrentO = "Wait for future updates";
            //addPast(UItext.text, CurrentO);
            //UItext.text = CurrentO;
            //Ctask++;
            UpdateChapter("Wait for future updates");
            two.sprite = NonCheck;
        }
            
    }
    
	void Start () {
        c1.Add("Find Books");
        c1.Add("Give Books to Girl (Press enter twice near her)");
        c1.Add("Wait for future updates");
        c1done = new bool[c1.Count];
        for(int i = 0; i < c1.Count; i++)
        {
            c1done[i] = false;
        }

        //setupObjectives(c1done, c1);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    /*
    public void setupObjectives(bool[] aredone,List<string> tasks)
    {
        int i = 0;
        for(i = 0; i < tasks.Count; i++)
        {
            if (aredone[i] == false)
                break;
        }
        Text Mission = Cur.GetComponentInChildren<Text>();
        Mission.text = tasks[i];

        int ctr = 0;
        for (i = i+1; i < tasks.Count; i++)
        {
            ctr++;
            GameObject copy = new GameObject();
            copy = Instantiate(Cur);
            copy.transform.SetParent(UObjective.transform);
            Text Fmission=copy.GetComponentInChildren<Text>();
            Fmission.text = tasks[i];
            copy.SetActive(true);
            copy.transform.localPosition = new Vector2(Cur.transform.localPosition.x, Cur.transform.localPosition.y-(ctr*10));
        }
    }
    */
    public void UpdateChapter(string chapname){
        CurrentO = chapname;
        //addPast(UItext.text, CurrentO);
        //UItext.text = CurrentO;
        Ctask++;
        Sound.PlaySound();
    }
    public void addPast(string past,string s)
    {
        PastText.text = PastText.text + "\n>" + past;
        CurrentText.text = "Current Objective:\n" + s;
    }
}
