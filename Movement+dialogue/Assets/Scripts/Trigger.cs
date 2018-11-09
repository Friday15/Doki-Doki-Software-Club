using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {
    public Conversation conv;
    public Canvas canvas;
    public Canvas vn;
    public Canvas ui;
    private int triggered =0;

    public ObjectiveController OC;
    //PLS DONT COPY IDK ITS JUST PARA MAY SAMPLE OBJECTIVES AKO
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name.Equals("Conversation"))
        {
            startConversation();
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Conversation"))
        {
            stopConversation();
        }
    }
    void Update()
    {
        if (conv.getIsConversing() == 1)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ui.gameObject.SetActive(true);
                vn.gameObject.SetActive(false);
                conv.setIsConversing(0);

                OC.MissionComplete(1, 2);
                //PLS DONT COPY IDK ITS JUST PARA MAY SAMPLE OBJECTIVES AKO
            }
        }
        if(triggered == 1)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                triggered = 0;
                conv.setIsConversing(1);
                canvas.gameObject.SetActive(false);
                vn.gameObject.SetActive(true);
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
