using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockControl : MonoBehaviour {
    public GameObject lock1;
    public GameObject arrow1;
    public GameObject lock2;
    public GameObject arrow2;
    public GameObject lock22;
    public GameObject arrow22;
    public GameObject lock3;
    public GameObject arrow3;
    public GameObject lock4;
    public GameObject arrow4;
    public GameObject lock42;
    public GameObject arrow42;
    public GameObject arrow43;
    public GameObject arrow44;
    public GameObject lock5;
    public GameObject arrow5;
    public GameObject arrow6;
    public GameObject arrow7;
    public GameObject arrow8;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        int chap;
        if (PlayerPrefs.HasKey("chapter"))
            chap = PlayerPrefs.GetInt("chapter");     
        else
            chap = 1;//CHANGE THIS TO MANUALLY TEST CHAPTERS
        if (chap >= 2)
        {
            lock1.SetActive(false);
            arrow1.SetActive(true);
        }
        if (chap >= 3)
        {
            lock2.SetActive(false);
            arrow2.SetActive(true);
            lock22.SetActive(false);
            arrow22.SetActive(true);
        }
        if (chap >= 4)
        {
            lock3.SetActive(false);
            arrow3.SetActive(true);
        }
        if (chap >= 5)
        {
            lock4.SetActive(false);
            arrow4.SetActive(true);
            lock42.SetActive(false);
            arrow42.SetActive(true);
            arrow43.SetActive(true);
            arrow44.SetActive(true);
        }
        if (chap >= 6)
        {
            lock5.SetActive(false);
            arrow5.SetActive(true);
        }
        if (chap >= 7)
            arrow6.SetActive(true);
        if (chap >= 8)
            arrow7.SetActive(true);
        if (chap >=9)
            arrow8.SetActive(true);

    }
}
