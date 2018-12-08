using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class FinishClick : MonoBehaviour {
    
    public Image img4;
    public Image img5;
    Color clr;
    public void finishClick()
    {
        clr = new Color(197 / 255f, 40 / 255f, 61 / 255f, 255 / 255f);
        if (img4.GetComponent<Image>().color ==clr && img5.GetComponent<Image>().color == clr)
        {
            String s = "REEEEEEEEEEE";
            PlayerPrefs.SetString("str", s);
            //PlayerPrefs.SetInt("int", 69);
            PlayerPrefs.Save();
            SceneManager.LoadScene(6);
        }else
            SceneManager.LoadScene(10);
        //img.gameObject.SetActive(false);
    }
}
