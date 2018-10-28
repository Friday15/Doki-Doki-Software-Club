using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {
    public Conversation conv;
    public Canvas canvas;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name.Equals("Conversation"))
        {
            conv.setIsConversing(1);
            canvas.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        if (conv.getIsConversing() == 1)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                canvas.gameObject.SetActive(false);
                conv.setIsConversing(0);
            }
        }
    }
}
