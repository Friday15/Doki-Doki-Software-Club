using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour {
    public Canvas canvas;
    public Canvas ui;
    private int triggered =0;
    public int isConversing = 0;
    private string npc = "";

    public ObjectiveController OC;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name.Equals("NPC") || col.gameObject.name.Equals("NPC2") || col.gameObject.name.Equals("NPC3") || col.gameObject.name.Equals("NPC4") || col.gameObject.name.Equals("NPC5"))
        {
            npc = col.gameObject.name.ToString();
            triggered = 1;
            canvas.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("NPC") || col.gameObject.name.Equals("NPC2") || col.gameObject.name.Equals("NPC3") || col.gameObject.name.Equals("NPC4") || col.gameObject.name.Equals("NPC5"))
        {
            npc = "";
            triggered = 0;
            canvas.gameObject.SetActive(false);
        }
    }
    void Update()
    {
        if (triggered == 1)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                triggered = 0;
                isConversing = 1;
                canvas.gameObject.SetActive(false);
                ui.gameObject.SetActive(false);
                OC.MissionComplete(1, 2);
                ui.gameObject.SetActive(true);
                npcConverse(npc);
                isConversing = 0;

            }
        }
    }
    private void npcConverse(string s)
    {
        if (npc.Equals("NPC"))
        {
            SceneManager.LoadScene(1);
        }
        if (npc.Equals("NPC2"))
        { 
            SceneManager.LoadScene(2);
        }
        if (npc.Equals("NPC3"))
        {
            SceneManager.LoadScene(3);
        }
        if (npc.Equals("NPC4"))
        {
            SceneManager.LoadScene(4);
        }
        if (npc.Equals("NPC5"))
        {
            SceneManager.LoadScene(5);
        }
    }
    
}
