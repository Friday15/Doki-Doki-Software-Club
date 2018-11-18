using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour {
    //public Conversation conv;
    public Canvas canvas;
    //public Canvas vn;
    public Canvas ui;
    private String triggered ="";
    public int isConversing = 0;
    

    public ObjectiveController OC;
    //PLS DONT COPY IDK ITS JUST PARA MAY SAMPLE OBJECTIVES AKO
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name.Equals("NPC") || col.gameObject.name.Equals("hammann1") || col.gameObject.name.Equals("hammann2"))
        {
            triggered = col.gameObject.name.ToString();
            canvas.gameObject.SetActive(true);
            print(col.gameObject.name);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("NPC") || col.gameObject.name.Equals("hammann1") || col.gameObject.name.Equals("hammann2"))
        {
            triggered = "";
            canvas.gameObject.SetActive(false);
        }
    }
    void Update()
    {
        if (!triggered.Equals(""))
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                isConversing = 1;
                canvas.gameObject.SetActive(false);
                ui.gameObject.SetActive(false);
            }
        }
        if (isConversing == 1)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ui.gameObject.SetActive(true);
                isConversing=0;
                OC.MissionComplete(1, 2);
                if(triggered.Equals("NPC"))
                    SceneManager.LoadScene(1);
                if (triggered.Equals("hammann1"))
                    SceneManager.LoadScene(2);
                if (triggered.Equals("hammann2"))
                    SceneManager.LoadScene(3);
                triggered = "";
            }
        }
        
    }
}
