using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ChoiceButton : MonoBehaviour
{

    public string option;
    public DialogueManager box;
    public Animator animator;
    public int number;

    // Use this for initialization
    void Start()
    {
        animator = GameObject.Find("GamePanel").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetText(string newText)
    {
        this.GetComponentInChildren<Text>().text = newText;
    }

    public void SetOption(string newOption)
    {
        this.option = newOption;
    }

    public void ParseOption(Button button)
    {
        string command = option.Split(',')[0];
        string commandModifier = option.Split(',')[1];
        if (command == "lineRight" || command == "lineWrong" || command == "line")
        {
            StopAllCoroutines();
            StartCoroutine(waitOneSecond(command, commandModifier, button));
        }
        else if (command == "scene")
        {
            box.playerTalking = false;
            box.StartCoroutine(box.FadeoutMiniGame(Convert.ToInt32(commandModifier)));
        }
    }

    public void selectButton(Button button)
    {
        button.Select();
        box.buttonSelect = number;
    }
    IEnumerator waitOneSecond(string command, string commandModifier, Button button)
    {
        
        if (command == "lineRight")
        {
            //button.GetComponent<Image>().color = new Color(113, 247, 159);
        }
        else if (command == "lineWrong")
        {
            //button.GetComponent<Image>().color = new Color(113, 247, 159);
        }

        box.DisableButtons();
        yield return new WaitForSeconds(0.5f);
        
        //animator.SetBool("wrongButton", false);
        //animator.SetBool("correctButton", true);      
        //animator.SetBool("correctButton", false);
        box.playerTalking = false;
        box.lineNum = int.Parse(commandModifier);
        print(box.lineNum + " CHOICE BUTTON");
        box.ShowDialogue();
        box.UpdateUI();
        box.Sound.PlaySound();
        box.StartCoroutine(box.DelayUser());
        //box.playerControl = true;
    }
}