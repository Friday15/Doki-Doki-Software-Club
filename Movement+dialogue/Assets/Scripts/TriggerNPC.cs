using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerNPC : MonoBehaviour {
    public int scene;
    private int triggered = 0;
    public Canvas canvas;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("hammann1"))
        {
            startConversation();
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Mhammann1"))
        {
            stopConversation();
        }
    }
    void Update () {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(scene);
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
