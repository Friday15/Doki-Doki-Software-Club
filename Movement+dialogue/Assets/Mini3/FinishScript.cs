using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishScript : MonoBehaviour {
    public GameObject slot1, slot2, slot3, slot4, slot5, slot6, slot7, slot8, slot9, slot10;
    private string[] answerR = new string[10] { "Clone", "Ctrl C", "Find and Replace", "Remix", "Recycle", "Hybrid", "Mashup", "404 Error", "Aggregator", "Retweet" };
    public void finishClick()
    {
        try
        {
            string[] answer = new string[10];
            answer[0] = slot1.GetComponentInChildren<Text>().text;
            answer[1] = slot2.GetComponentInChildren<Text>().text;
            answer[2] = slot3.GetComponentInChildren<Text>().text;
            answer[3] = slot4.GetComponentInChildren<Text>().text;
            answer[4] = slot5.GetComponentInChildren<Text>().text;
            answer[5] = slot6.GetComponentInChildren<Text>().text;
            answer[6] = slot7.GetComponentInChildren<Text>().text;
            answer[7] = slot8.GetComponentInChildren<Text>().text;
            answer[8] = slot9.GetComponentInChildren<Text>().text;
            answer[9] = slot10.GetComponentInChildren<Text>().text;
            int check = 0;
            for (int i = 0; i < 10; i++)
            {
                if (answerR[i] == answer[i])
                    check++;
            }
            if (check == 10)
            {
                //if correct answer
                SceneManager.LoadScene(8);
            }
            else
            {
                //if wrong answer
                SceneManager.LoadScene(12);
            }
        }catch(Exception e)
        {

        }
        
    }
        
}
