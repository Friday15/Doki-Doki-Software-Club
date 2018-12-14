using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryController : MonoBehaviour {

    private Image [] inventoryArray = new Image[9];
    private int status;
	// Use this for initialization
	void Start () {
        inventoryArray[0] = GameObject.Find("smartPhone").GetComponent<Image>();
        inventoryArray[1] = GameObject.Find("scroll").GetComponent<Image>();
        inventoryArray[2] = GameObject.Find("nutbook").GetComponent<Image>();
        inventoryArray[3] = GameObject.Find("flask").GetComponent<Image>();
        inventoryArray[4] = GameObject.Find("tablet").GetComponent<Image>();
        inventoryArray[5] = GameObject.Find("attache").GetComponent<Image>();
        inventoryArray[6] = GameObject.Find("stick").GetComponent<Image>();
        inventoryArray[7] = GameObject.Find("gavel").GetComponent<Image>();
        inventoryArray[8] = GameObject.Find("certificate").GetComponent<Image>();

        for(int i = 0; i < 9; i++)
        {
            inventoryArray[i].color = new Color32(128, 128, 128, 255);
        }
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void updateInventory()
    {
        status = PlayerPrefs.GetInt("inventory");
        //status = 4;
        for(int i = 0; i < status - 1; i++)
        {
            inventoryArray[i].color = new Color32(255, 255, 255, 255);
        }
    }
}
