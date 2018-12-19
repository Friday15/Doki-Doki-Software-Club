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
    public Transform NPC1;
    public Transform NPC2;
    public Transform NPC3;
    public Transform NPC4;
    public Transform NPC5;
    public Transform NPC6;
    public Transform NPC7;
    public Transform NPC8;
    public Transform NPC9;
    public GameObject warning;
    

    public ObjectiveController OC;
    private void OnTriggerEnter2D(Collider2D col)
    {
        int chap;
        if (PlayerPrefs.HasKey("chapter"))
            chap = PlayerPrefs.GetInt("chapter");
        else
            chap = 1;
        if (col.gameObject.name.Equals("NPC") &&chap==1)
        {
            npc = col.gameObject.name.ToString();
            warning.SetActive(true);
            warning.transform.position=new Vector2(NPC1.position.x, NPC1.position.y);
            triggered = 1;
            //canvas.gameObject.SetActive(true);
        }
        if (col.gameObject.name.Equals("NPC2") && chap == 2)
        {
            npc = col.gameObject.name.ToString();
            warning.SetActive(true);
            warning.transform.position = new Vector2(NPC2.position.x, NPC2.position.y);
            triggered = 1;
            //canvas.gameObject.SetActive(true);
        }
        if (col.gameObject.name.Equals("NPC3") && chap == 3)
        {
            npc = col.gameObject.name.ToString();
            warning.SetActive(true);
            warning.transform.position = new Vector2(NPC3.position.x, NPC3.position.y);
            triggered = 1;
            //canvas.gameObject.SetActive(true);
        }
        if (col.gameObject.name.Equals("NPC4") && chap == 4)
        {
            npc = col.gameObject.name.ToString();
            warning.SetActive(true);
            warning.transform.position = new Vector2(NPC4.position.x, NPC4.position.y);
            triggered = 1;
            //canvas.gameObject.SetActive(true);
        }
        if (col.gameObject.name.Equals("NPC5") && chap == 5)
        {
            npc = col.gameObject.name.ToString();
            warning.SetActive(true);
            warning.transform.position = new Vector2(NPC5.position.x, NPC5.position.y);
            triggered = 1;
            //canvas.gameObject.SetActive(true);
        }
        if (col.gameObject.name.Equals("NPC6") && chap == 6)
        {
            npc = col.gameObject.name.ToString();
            warning.SetActive(true);
            warning.transform.position = new Vector2(NPC6.position.x, NPC6.position.y);
            triggered = 1;
            //canvas.gameObject.SetActive(true);
        }
        if (col.gameObject.name.Equals("NPC7") && chap == 7)
        {
            npc = col.gameObject.name.ToString();
            warning.SetActive(true);
            warning.transform.position = new Vector2(NPC7.position.x, NPC7.position.y);
            triggered = 1;
            //canvas.gameObject.SetActive(true);
        }
        if (col.gameObject.name.Equals("NPC8") && chap == 8)
        {
            npc = col.gameObject.name.ToString();
            warning.SetActive(true);
            warning.transform.position = new Vector2(NPC8.position.x, NPC8.position.y);
            triggered = 1;
            //canvas.gameObject.SetActive(true);
        }
        if (col.gameObject.name.Equals("NPC9") && chap == 9)
        {
            npc = col.gameObject.name.ToString();
            warning.SetActive(true);
            warning.transform.position = new Vector2(NPC9.position.x, NPC9.position.y);
            triggered = 1;
            //canvas.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("NPC") || col.gameObject.name.Equals("NPC2") || col.gameObject.name.Equals("NPC3") || col.gameObject.name.Equals("NPC4") || col.gameObject.name.Equals("NPC5") || col.gameObject.name.Equals("NPC6") || col.gameObject.name.Equals("NPC7") || col.gameObject.name.Equals("NPC8") || col.gameObject.name.Equals("NPC9"))
        {
            npc = "";
            warning.SetActive(false);
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
                //canvas.gameObject.SetActive(false);
                ui.gameObject.SetActive(false);
                //OC.MissionComplete(1, 2);
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
            SceneManager.LoadScene(9);
            PlayerPrefs.SetInt("chapter", 2);
        }
        if (npc.Equals("NPC2"))
        { 
            SceneManager.LoadScene(1);
            PlayerPrefs.SetInt("chapter", 3);
        }
        if (npc.Equals("NPC3"))
        {
            SceneManager.LoadScene(2);
            PlayerPrefs.SetInt("chapter", 4);
        }
        if (npc.Equals("NPC4"))
        {
            SceneManager.LoadScene(3);
            PlayerPrefs.SetInt("chapter", 5);
        }
        if (npc.Equals("NPC5"))
        {
            SceneManager.LoadScene(4);
            PlayerPrefs.SetInt("chapter", 6);
        }
        if (npc.Equals("NPC6"))
        {
            SceneManager.LoadScene(5);
            PlayerPrefs.SetInt("chapter", 7);
        }
        if (npc.Equals("NPC7"))
        {
            SceneManager.LoadScene(6);
            PlayerPrefs.SetInt("chapter", 8);
        }
        if (npc.Equals("NPC8"))
        {
            SceneManager.LoadScene(7);
            PlayerPrefs.SetInt("chapter", 9);
        }
        if (npc.Equals("NPC9"))
        {
            SceneManager.LoadScene(8);
            PlayerPrefs.SetInt("chapter", 10);
        }
    }
    
}
