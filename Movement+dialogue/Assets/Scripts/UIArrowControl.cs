using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using UnityEngine.UI;

public class UIArrowControl : MonoBehaviour
{
    public Button left;
    public Button right;
    public bool isleft;
    public Text leftpage;
    public Text rightpage;

    public void clicked()
    {
        int page = PlayerPrefs.GetInt("page");
        int chap = PlayerPrefs.GetInt("chapter");
        if (page < 1 || page > chap)
        {
            page = 1;
        }
        if (isleft)
        {
            page--;
            PlayerPrefs.SetInt("page", page);
            print("LEFT :" + page);
        }
        else
        {
            page++;
            PlayerPrefs.SetInt("page", page);
            print("RIGHT :" + page);
        }
    }
    // Use this for initialization
    void Start () {
        print(isleft);
        print(PlayerPrefs.GetInt("page"));
	}
	
	// Update is called once per frame
	void Update () {
        int page = PlayerPrefs.GetInt("page");
        int chap = PlayerPrefs.GetInt("chapter");

        if (isleft)
        {
            if (page == 1)
            {
                left.enabled = false;
                left.image.color = new Color32(128, 128, 128, 255);
            }
            else
            {
                left.enabled = true;
                left.image.color = new Color32(255, 255, 255, 255);
            }
        }

        if (!isleft)
        {
            if (page == chap)
            {
                right.enabled = false;
                right.image.color = new Color32(128, 128, 128, 255);
            }
            else
            {
                right.enabled = true;
                right.image.color = new Color32(255, 255, 255, 255);
            }
        }    


        if (page == 1)
        {
            leftpage.text = "CHAPTER 1:\nLOST";
            rightpage.text = "1. Learn about objectives\n2.Learn about UI landscape\n3.Learn how to walk\n4.Learn what to do when you see a text bubble with an exclamation point\n5.Learn about items that need to be collected";
        }
        if (page == 2)
        {
            leftpage.text = "CHAPTER 2:\nREFERENCE DESK";
            rightpage.text = "1. Find and talk to LORA\n2. Retrieve the smartphone from her";
        }
        if (page == 3)
        {
            leftpage.text = "CHAPTER 3:\nARCHIVES";
            rightpage.text = "1. Find and talk to ArRa\n2. Retrieve the scroll from her";
        }
        if (page == 4)
        {
            leftpage.text = "CHAPTER 4:\nANERICAN CORNER";
            rightpage.text = "1. Find and talk to ASRA\n2. Retrieve the netbook from her";
        }
        if (page == 5)
        {
            leftpage.text = "CHAPTER 5:\nCOLLEGE LIBRARY";
            rightpage.text = "1. Find and talk to SciTRa\n2. Retrieve the flask from him";
        }
        if (page == 6)
        {
            leftpage.text = "CHAPTER 6:\nINTEGRATED SCHOOL LIBRARY";
            rightpage.text = "1. Find and talk to KIRA\n2. Retrieve the tablet from her";
        }
        if (page == 7)
        {
            leftpage.text = "CHAPTER 7:\nMEC LIBRARY";
            rightpage.text = "1.Find and talk to CoRA\n2. Accomplish mini - game\n3.Retrieve the attache case from her";

        }
        if (page == 8)
        {
            leftpage.text = "CHAPTER 8:\nBBLRC";
            rightpage.text = "1.Find and talk to EDRA\n2. Accomplish mini - game\n3.Retrieve the teacher's stick from him";
        }
        if (page == 9)
        {
            leftpage.text = "CHAPTER 9:\nBGC LAW LIB";
            rightpage.text = "1.Find and talk to LeRa\n2. Accomplish mini - game\n3.Retrieve the gavel from her";
        }


    }
}
