using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockControl : MonoBehaviour {

    public inventoryController inv;
    // Use this for initialization
    void Start () {
        //PlayerPrefs.SetInt("chapter", 1);
        //PlayerPrefs.SetInt("page", 1);
    }
	
	// Update is called once per frame
	void Update () {
        int chap;
        if (PlayerPrefs.HasKey("chapter"))
            chap = PlayerPrefs.GetInt("chapter");     
        else
            chap = 1;//CHANGE THIS TO MANUALLY TEST CHAPTERS
        if (chap == 2)
        {

        }
        if (chap == 3)
        {

        }
        if (chap == 4)
        {

        }
        if (chap == 5)
        {

        }
        if (chap == 6)
        {

        }
        if (chap == 7)
        {

        }
        if (chap == 8)
        {

        }
        if (chap == 9)
        {

        }
        if (chap != 1)
        {
            try
            {
                //inventoryController inventory = GameObject.Find("inventory").GetComponent<inventoryController>();
                inventoryController inventory = inv;
                inventory.updateInventory();
            }catch(Exception e)
            {

            }
        }
    }
}
