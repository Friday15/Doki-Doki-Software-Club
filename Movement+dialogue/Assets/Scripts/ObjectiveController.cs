using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveController : MonoBehaviour {
    
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

    }
    
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        int chap;
        if (PlayerPrefs.HasKey("chapter"))
            chap = PlayerPrefs.GetInt("chapter");
        else
            chap = 1;

        if (chap == 1)
        {
            CurrentText.text="Talk to Ria";
        }else if (chap == 2)
        {
            CurrentText.text = "Meet LORA at the Reference Desk";
        }
        else if (chap == 3)
        {
            CurrentText.text = "Meet ArRA at the Archives";
        }
        else if (chap == 4)
        {
            CurrentText.text = "Meet ASRA at the American Corner";
        }
        else if (chap == 5)
        {
            CurrentText.text = "Meet SciTRA at the College Library";
        }
        else if (chap == 6)
        {
            CurrentText.text = "Meet KIRA at the Integrated School";
        }
        else if (chap == 7)
        {
            CurrentText.text = "Meet CoRA at the Business Library";
        }
        else if (chap == 8)
        {
            CurrentText.text = "Meet EDRA at the BBLRC";
        }
        else if (chap == 9)
        {
            CurrentText.text = "Meet LeRA at the Law Library";
        }
        else
        {
            CurrentText.text = "Talk to LERA";
            one.sprite = check;
        }
    }

}
