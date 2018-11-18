using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{

    DialogueParser parser;

    public string dialogue, characterName;
    public int lineNum;
    int pose;
    string position;
    string[] options;
    public bool playerTalking;
    public bool clickOnce = false;
    public bool playerControl;
    List<Button> buttons = new List<Button>();

    public Text dialogueBox;
    public Text nameBox;
    public GameObject choiceBox;
    public AnimatedText animatedText;
    public Animator transition;
    public Animator charAnimator;

    // Use this for initialization
    void Start()
    {
        dialogue = "";
        characterName = "";
        pose = 0;
        position = "L";
        playerTalking = true;
        parser = GameObject.Find("DialogueParser").GetComponent<DialogueParser>();
        animatedText = GameObject.Find("TextBox").GetComponent<AnimatedText>();
        transition = GameObject.Find("AnimPanel").GetComponent<Animator>();
        charAnimator = GameObject.Find("GamePanel").GetComponent<Animator>();
        lineNum = -1;
        playerControl = true;
        //transition.SetTrigger("fadein");
    }

    // Update is called once per frame
    void Update()
    {
        if (!clickOnce)     //preloads background
        {
            lineNum++;
            ShowDialogue();
            print("CLICKONCE "+lineNum);
            UpdateUI();
            clickOnce = true;
        }
        if (!playerTalking)
        {
            ClearButtons();
        }
        if (playerControl)
        {
            if (!dialogueBox.GetComponent<AnimatedText>().done && !dialogueBox.GetComponent<AnimatedText>().cancel && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown("return")))   //skips the dialogue
            {
                /*
                if (parser.GetName(lineNum + 1) != characterName && !charAnimator.GetBool("fadeout" + characterName) && (charAnimator.GetBool("idle" + characterName) || charAnimator.GetBool("fadein" + characterName)))
                {
                 charAnimator.SetBool("fadeout" + characterName, true);
                 charAnimator.SetBool("idle" + characterName, false);
                 charAnimator.SetBool("fadein" + characterName, false);
                }*/
                //SetAnimation();
                dialogueBox.GetComponent<AnimatedText>().cancel = true;
                print("CANCELLING TEXT " + lineNum);
            }

            else if (((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown("return")) && playerTalking == false && dialogueBox.GetComponent<AnimatedText>().done))   //if dialogue is already skipped OR already done, go to next line
            {

                if (parser.GetName(lineNum) == characterName && !charAnimator.GetBool("fadeout" + characterName) && (charAnimator.GetBool("idle" + characterName) || charAnimator.GetBool("fadein" + characterName)))
                {
                    charAnimator.SetBool("fadeout" + characterName, true);
                    charAnimator.SetBool("idle" + characterName, false);
                    charAnimator.SetBool("fadein" + characterName, false);
                }
                //SetAnimation();
                dialogueBox.GetComponent<AnimatedText>().cancel = false;
                lineNum++;
                ShowDialogue();
                print("ACTION " + lineNum);
                UpdateUI();
                //SetAnimation();
            }
        }

    }

    public void ShowDialogue()
    {
        ParseLine();
    }

    public void UpdateUI()
    {
        dialogueBox.text = dialogue;
        dialogueBox.GetComponent<AnimatedText>().startAnim();
        nameBox.text = characterName;
    }

    void ClearButtons()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            print("Clearing buttons");
            Button b = buttons[i];
            buttons.Remove(b);
            Destroy(b.gameObject);
        }
    }

    void ParseLine()
    {
        try
        {
            print(parser.GetContent(lineNum)+" PARSE LINE");
        }
        catch(System.Exception e)
        {
            print(e.StackTrace);
        }
        
        if (parser.GetName(lineNum) != "Player")
        {
            if (parser.GetContent(lineNum) == "`loadchar")
            {
                playerTalking = false;
                characterName = parser.GetName(lineNum);
                pose = parser.GetPose(lineNum);
                position = parser.GetPosition(lineNum);
                DisplayImages();
                //charAnimator.SetBool("idle" + characterName, false);
                //charAnimator.SetBool("fadein" + characterName, false);
                //charAnimator.SetBool("fadeout" + characterName, true);
            }

            else
            {
                playerTalking = false;
                characterName = parser.GetName(lineNum);
                dialogue = parser.GetContent(lineNum);
                pose = parser.GetPose(lineNum);
                position = parser.GetPosition(lineNum);
                DisplayImages();
            }
        }
        else
        {
            if (parser.GetContent(lineNum) == "`background")
            {
                playerTalking = false;
                characterName = "";
                dialogue = "";
                pose = parser.GetPose(lineNum);
                position = "";
                ChangeBackground();
            }
            else if(parser.GetContent(lineNum) == "`jump")
            {
                lineNum = parser.GetPose(lineNum);
                ShowDialogue();
            }
            else if(parser.GetContent(lineNum) == "`clear")
            {
                print("CLEARING "+ parser.GetPosition(lineNum));
                ResetImages(parser.GetPosition(lineNum));
                lineNum++;
                ShowDialogue();
                if (parser.GetContent(lineNum+1) != "`end")
                {
                    characterName = "";
                    dialogue = "";
                    UpdateUI();
                }
            }
            else if(parser.GetContent(lineNum) == "`end")
            {
                endScene();
            }
            else
            {
                print("CREATING BUTTON");
                playerTalking = true;
                characterName = "";
                dialogue = "";
                pose = 0;
                position = "";
                options = parser.GetOptions(lineNum);
                CreateButtons();
            }        
        }
    }

    void CreateButtons()
    {
        for (int i = 0; i < options.Length; i++)
        {
            GameObject button = (GameObject)Instantiate(choiceBox);
            Button b = button.GetComponent<Button>();
            ChoiceButton cb = button.GetComponent<ChoiceButton>();
            cb.SetText(options[i].Split(':')[0]);
            cb.option = options[i].Split(':')[1];
            cb.box = this;
            b.transform.SetParent(this.transform);
            b.transform.localPosition = new Vector3(0, -25 + (i * 50));
            b.transform.localScale = new Vector3(1, 1, 1);
            buttons.Add(b);
        }
        if (playerTalking)
        {
            print("SHOULD PRINT");
        }
    }

    void ResetImages(string charName)
    {
        print("RESETIMAGES" + charName);
        GameObject character = GameObject.Find(charName);
        SpriteRenderer currSprite = character.GetComponent<SpriteRenderer>();
        currSprite.sprite = null;
    }

    void DisplayImages()
    {
        if (characterName != "")
        {
            SetAnimation();
            print("DISPLAY " + characterName);
            GameObject character = GameObject.Find(characterName);
            SetSpritePositions(character);
        }
    }

    void SetAnimation()
    {
        if((charAnimator.GetBool("fadein" + characterName) || charAnimator.GetBool("idle" + characterName)) && parser.GetName(lineNum + 1) != characterName)
        //if ((charAnimator.GetCurrentAnimatorStateInfo(0).IsName("fadein" + characterName) || charAnimator.GetCurrentAnimatorStateInfo(0).IsName("idle" + characterName)))
        {
            charAnimator.SetBool("fadeout" + characterName, true);
            charAnimator.SetBool("idle" + characterName, false);
            charAnimator.SetBool("fadein" + characterName, false);
            print("fadeout " + characterName);
            //print("Animation playing: " + charAnimator.GetCurrentAnimatorStateInfo(0));
            //print(parser.GetName(lineNum + 1) + "next name");
        }

        else if((charAnimator.GetBool("fadeout" + characterName) || charAnimator.GetBool("fadein" + characterName)) || (parser.GetName(lineNum + 1) == characterName && charAnimator.GetBool("idle" + characterName)))
        //else if (charAnimator.GetCurrentAnimatorStateInfo(0).IsName("fadeout" + characterName))
        {
            charAnimator.SetBool("fadeout" + characterName, false);
            //charAnimator.SetTrigger("idle" + characterName);
            charAnimator.SetBool("idle" + characterName, true);
            print("idle " + characterName);
            //print("Animation playing: " + charAnimator.GetCurrentAnimatorStateInfo(0));
        }

        else if(!charAnimator.GetBool("fadein" + characterName))
        //else if (charAnimator.GetCurrentAnimatorStateInfo(0).IsName("start" + characterName))
        {
            //charAnimator.SetTrigger("fadein" + characterName);
            charAnimator.SetBool("fadein" + characterName, true);
            print("fadein " + characterName);
            //print("Animation playing: " + charAnimator.GetCurrentAnimatorStateInfo(0));
            StartCoroutine(WaitOneSecondChar());
        }
        //else
        //{
            //print("REEEE ANIMATION");
            //charAnimator.SetTrigger("fadeinArRA");
            //print("Animation playing: "+ charAnimator.GetCurrentAnimatorStateInfo(0));
        //}
    }

    void SetSpritePositions(GameObject spriteObj)
    {
        SpriteRenderer currSprite = spriteObj.GetComponent<SpriteRenderer>();

        if (position == "L")
        {
            spriteObj.transform.position = new Vector3(250, 180);
        }
        else if (position == "R")
        {
            spriteObj.transform.position = new Vector3(700, 180);
        }
        else if (position == "M")
        {
            spriteObj.transform.position = new Vector3(500, 180);
        }
        else if (position == "LF")  //F == flip
        {
            currSprite.flipX = true;
            spriteObj.transform.position = new Vector3(250, 180);
        }
        else if (position == "RF")
        {
            currSprite.flipX = true;
            spriteObj.transform.position = new Vector3(700, 180);
        }
        else if (position == "MF")
        {
            currSprite.flipX = true;
            spriteObj.transform.position = new Vector3(500, 180);
        }
        spriteObj.transform.position = new Vector3(spriteObj.transform.position.x, spriteObj.transform.position.y, 0);

        currSprite.sprite = spriteObj.GetComponent<Character>().characterPoses[pose];
        //transition.SetTrigger("fadeinChar");
    }

    void ChangeBackground()
    {
        print("CHANGE BG");
        GameObject bg = GameObject.Find("Background");
        Texture bgTexture = (Texture)bg.GetComponent<BackgroundScript>().bg[pose];
        Shader shader = Shader.Find("Unlit/Texture");
        StartCoroutine(WaitAnimToFinish(bg, bgTexture));
        bg.GetComponent<Renderer>().material.shader = shader; 
        playerTalking = true;
    }

    IEnumerator WaitAnimToFinish(GameObject bg, Texture bgTexture)
    {
        if (clickOnce)
        {
            //playerControl = false;
            transition.SetBool("fadeout", true);

            yield return new WaitForSeconds(1);

            transition.SetBool("fadeout", false);
            yield return new WaitForSeconds(1.5f);
            bg.GetComponent<Renderer>().material.mainTexture = bgTexture;
            transition.SetBool("fadein", true);

            yield return new WaitForSeconds(1);

            transition.SetBool("fadein", false);
            yield return new WaitForSeconds(0.5f);
            //playerControl = true;
        }
        else
        {
            //print("linenum before " + lineNum);
            bg.GetComponent<Renderer>().material.mainTexture = bgTexture;
            yield return new WaitForSeconds(1);
        }

        //print("wait 1 sec");
        lineNum++;
        //print("linenum after " + lineNum);
        ShowDialogue();
        UpdateUI();
        //playerTalking = false;
    }

    void endScene()
    {
        playerTalking = true;
        StartCoroutine(WaitAnimToFinishEnd());
    }

    IEnumerator WaitAnimToFinishEnd()
    {
        transition.SetBool("fadeout", true);
        yield return new WaitForSeconds(1.5f);
        transition.SetBool("fadeout", false);
        SceneManager.LoadScene(0);
    }

    IEnumerator WaitOneSecondChar()
    {
        //playerControl = false;
        yield return new WaitForSeconds(1);
        charAnimator.SetBool("fadein" + characterName, false);
        yield return new WaitForSeconds(0.1f);
        charAnimator.SetBool("idle" + characterName, true);
        //playerControl = true;
        print("Content " + parser.GetContent(lineNum));
        if (parser.GetContent(lineNum) == "`loadchar")
        {
            //playerControl = false;
            yield return new WaitForSeconds(0.1f);
            charAnimator.SetBool("idle" + characterName, false);
            yield return new WaitForSeconds(0.1f);
            charAnimator.SetBool("fadeout" + characterName, true);
            print("fadeout " + characterName);
            lineNum++;
            ShowDialogue();
            UpdateUI();
            //playerControl = true;
        }
    }

}