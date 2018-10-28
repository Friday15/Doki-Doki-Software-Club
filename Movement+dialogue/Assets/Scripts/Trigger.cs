﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {
    public Conversation conv;
    public Canvas canvas;
    public Canvas vn;
    private int triggered =0;
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
                vn.gameObject.SetActive(false);
                conv.setIsConversing(0);
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
