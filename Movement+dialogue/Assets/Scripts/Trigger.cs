using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour {
    public Canvas canvas;
    public Canvas ui;
    private int triggered =0;
    private int isConversing=0;

    public int getIsConversing()
    {
        return isConversing;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name.Equals("hammann"))
        {
            startConversation();
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("hammann"))
        {
            stopConversation();
        }
    }
    void Update()
    {
        if (isConversing == 1)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ui.gameObject.SetActive(true);
                //vn.gameObject.SetActive(false);
                
                isConversing=0;
            }
        }
        if(triggered == 1)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                triggered = 0;
                isConversing=1;
                canvas.gameObject.SetActive(false);
                SceneManager.LoadScene(1);
                //vn.gameObject.SetActive(true);
                ui.gameObject.SetActive(false);
            }
        }
    }

    private void startConversation()
    {
        triggered = 1;
        canvas.gameObject.SetActive(true);
    }
    private void stopConversation()
    {
        triggered = 0;
        canvas.gameObject.SetActive(false);
    }
}
