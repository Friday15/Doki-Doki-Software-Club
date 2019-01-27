using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour {
   
    public void finishClick()
    {
        String s = PlayerPrefs.GetString("str").ToString();
        print(""+s);
        //int i = PlayerPrefs.GetInt("int");
        //print(i);
        SceneManager.LoadScene(9);
    }
}
