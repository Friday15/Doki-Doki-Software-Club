using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{

    DialogueParser parser;

    public string dialogue, characterName, playerName;
    public int lineNum;
    public int pose, buttonSelect;
    string position;
    string[] options;
    public bool playerTalking;
    public bool clickOnce = false;
    public bool playerControl;
    public bool doneButton;
    public bool preLoadChar;
    List<Button> buttons = new List<Button>();

    public Text dialogueBox;
    public Text nameBox;
    public GameObject choiceBox;
    public AnimatedText animatedText;
    public Animator transition;
    public Animator charAnimator;
    public Animator cameraAnimator;
    public AudioController Sound;
    public GameObject thingy;

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
        cameraAnimator = GameObject.Find("Main Camera").GetComponent<Animator>();
        thingy = GameObject.Find("thingy");
        lineNum = -1;
        playerName = "Yukino";
    }

    // Update is called once per frame
    void Update()
    {
        if (!clickOnce)     //preloads background
        {
            if (PlayerPrefs.HasKey("lineNum"))
            {

                pose = parser.GetPose(0);
                ChangeBackground();
                characterName = parser.GetName(1);
                pose = parser.GetPose(1);
                position = parser.GetPosition(1);
                lineNum = 1;
                print(parser.GetContent(lineNum));
                preLoadChar = true;
                DisplayImages();

                print(PlayerPrefs.GetInt("lineNum") + "    REEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
                clickOnce = true;
                //lineNum++;
            }
            else
            {
                lineNum++;
                ShowDialogue();
                print("CLICKONCE " + lineNum);
                UpdateUI();
                clickOnce = true;
                thingy.SetActive(false);
                charAnimator.SetBool("startIndicator", false);
                charAnimator.SetBool("stopIndicator", true);
            }
        }
        if (!playerTalking)
        {
            ClearButtons();
        }
        else
        {
            //if(buttons.Count == 1)
            //{
              //  buttons[0].Select();
            //}
        }
        if (playerControl == true)
        {
            if (!dialogueBox.GetComponent<AnimatedText>().done && !dialogueBox.GetComponent<AnimatedText>().cancel && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown("return") || Input.GetKeyDown("space")))   //skips the dialogue
            {
                dialogueBox.GetComponent<AnimatedText>().cancel = true;
                print("CANCELLING TEXT " + lineNum);
            }

            else if (((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown("return") || Input.GetKeyDown("space")) && playerTalking == false && dialogueBox.GetComponent<AnimatedText>().done))   //if dialogue is already skipped OR already done, go to next line
            {

                if (parser.GetName(lineNum) == characterName && !charAnimator.GetBool("fadeout" + characterName) && (charAnimator.GetBool("idle" + characterName) || charAnimator.GetBool("fadein" + characterName)))
                {
                    charAnimator.SetBool("fadeout" + characterName, true);
                    charAnimator.SetBool("idle" + characterName, false);
                    charAnimator.SetBool("fadein" + characterName, false);
                }
                Sound.PlaySound();
                dialogueBox.GetComponent<AnimatedText>().cancel = false;
                lineNum++;
                ShowDialogue();
                print("ACTION " + lineNum);
                UpdateUI();
                thingy.SetActive(false);
                charAnimator.SetBool("startIndicator", false);
                charAnimator.SetBool("stopIndicator", true);
                StartCoroutine(DelayUser());
            }
        }

    }

    public void ShowDialogue()
    {
        ParseLine();
    }

    public void UpdateUI()
    {
        if(parser.GetContent(lineNum) != "`loadchar"){
            if (dialogue.Contains("(Player)"))
                dialogue = PutPlayerName(dialogue);

            dialogueBox.text = dialogue;
            dialogueBox.GetComponent<AnimatedText>().startAnim();
            nameBox.text = characterName;
        }
    }

    public string PutPlayerName(string text)
    {
        if (text.Contains("(Player)"))
        {
            text = text.Replace("(Player)", playerName);
            print("REPLACED " + text);
        }
        return text;
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

    public void DisableButtons()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            Button b = buttons[i];
            b.interactable = false;
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
            print(parser.GetContent(lineNum) + " REEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
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
            else if(parser.GetContent(lineNum) == "`explosion")
            {
                StartCoroutine(Explosion());
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
            else if(parser.GetContent(lineNum) == "`tutorial1" || parser.GetContent(lineNum) == "`tutorial2" || parser.GetContent(lineNum) == "`tutorial3" || parser.GetContent(lineNum) == "`tutorialend")
            {
                charAnimator.SetTrigger(parser.GetContent(lineNum));
                lineNum++;
                ShowDialogue();
                UpdateUI();
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
                print("PRINT CREATE");
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
            if ((options[i].Split(':')[0]).Contains("(Player)"))
                cb.SetText(PutPlayerName(options[i].Split(':')[0]));
            else
                cb.SetText(options[i].Split(':')[0]);
            cb.option = options[i].Split(':')[1];
            cb.number = i;
            cb.box = this;
            ColorBlock block = b.colors;

            if ((cb.option.Split(',')[0]) == "lineRight")
                block.pressedColor = new Color32(113, 247, 159, 255);
            else if ((cb.option.Split(',')[0]) == "lineWrong")
                block.pressedColor = new Color32(213, 87, 59, 255);
            if ((cb.option.Split(',')[0]) == "scene")
                miniGame();

            b.colors = block;
            b.transform.SetParent(GameObject.Find("GamePanel").transform);
            b.transform.localPosition = new Vector3(0, -25 + (i * 50));
            b.transform.localScale = new Vector3(1, 1, 1);
            buttons.Add(b);
            thingy.SetActive(false);
            charAnimator.SetBool("startIndicator", false);
            charAnimator.SetBool("stopIndicator", true);
        }
        if (playerTalking)
        {
            print("SHOULD PRINT");
        }

        if (buttons.Count > 1)
        {
            playerControl = false;
            characterName = parser.GetName(lineNum - 1);
            dialogue = parser.GetContent(lineNum - 1);
            dialogueBox.text = dialogue;
            nameBox.text = characterName;
            thingy.SetActive(false);
        }
        //buttons[buttons.Count - 1].Select();
        //buttonSelect = buttons.Count - 1;
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
        {
            charAnimator.SetBool("fadeout" + characterName, true);
            charAnimator.SetBool("idle" + characterName, false);
            charAnimator.SetBool("fadein" + characterName, false);
            print("fadeout " + characterName);
        }

        else if((charAnimator.GetBool("fadeout" + characterName) || charAnimator.GetBool("fadein" + characterName)) || (parser.GetName(lineNum + 1) == characterName && charAnimator.GetBool("idle" + characterName)))
        {
            charAnimator.SetBool("fadeout" + characterName, false);
            charAnimator.SetBool("idle" + characterName, true);
            print("idle " + characterName);
        }

        else if(!charAnimator.GetBool("fadein" + characterName))
        {
            charAnimator.SetBool("fadein" + characterName, true);
            print("fadein " + characterName);
            StartCoroutine(WaitOneSecondChar());
        }
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
        StartCoroutine(ChangeBGTransition(bg, bgTexture));
        bg.GetComponent<Renderer>().material.shader = shader; 
        playerTalking = true;
    }

    void endScene()
    {
        playerTalking = true;
        StartCoroutine(WaitAnimToFinishEnd());
    }

    void miniGame()
    {
        PlayerPrefs.DeleteKey("lineNum");
        PlayerPrefs.SetInt("lineNum", lineNum);
    }

    IEnumerator ChangeBGTransition(GameObject bg, Texture bgTexture)
    {
        playerControl = false;
        if (clickOnce)
        {
            transition.SetBool("fadeout", true);

            yield return new WaitForSeconds(1);

            transition.SetBool("fadeout", false);
            yield return new WaitForSeconds(1.5f);
            bg.GetComponent<Renderer>().material.mainTexture = bgTexture;
            transition.SetBool("fadein", true);

            yield return new WaitForSeconds(1);

            transition.SetBool("fadein", false);
        }
        else
        {       
            transition.SetBool("fadein", true);
            bg.GetComponent<Renderer>().material.mainTexture = bgTexture;
            yield return new WaitForSeconds(1.5f);
            transition.SetBool("fadein", false);            
        }

        lineNum++;
        ShowDialogue();
        UpdateUI();
        yield return new WaitForSeconds(1f);
        playerControl = true;
    }

    IEnumerator WaitAnimToFinishEnd()
    {
        transition.SetBool("fadeout", true);
        yield return new WaitForSeconds(1.5f);
        transition.SetBool("fadeout", false);
        PlayerPrefs.DeleteKey("lineNum");
        SceneManager.LoadScene(0);
    }

    IEnumerator WaitOneSecondChar()
    {
        yield return new WaitForSeconds(1);
        charAnimator.SetBool("fadein" + characterName, false);
        yield return new WaitForSeconds(0.1f);
        charAnimator.SetBool("idle" + characterName, true);
        //playerControl = true;
        print("Content " + parser.GetContent(lineNum));
        if (parser.GetContent(lineNum) == "`loadchar" || preLoadChar)
        {
            print("THIS SHOULD PRINT");
            yield return new WaitForSeconds(0.1f);
            charAnimator.SetBool("idle" + characterName, false);
            yield return new WaitForSeconds(0.1f);
            charAnimator.SetBool("fadeout" + characterName, true);
            print("fadeout " + characterName);
            if (PlayerPrefs.HasKey("lineNum"))
            {
                preLoadChar = false;
                lineNum = PlayerPrefs.GetInt("lineNum");
            }
            else
            {
                lineNum++;
                ShowDialogue();
                UpdateUI();
            }
            charAnimator.SetBool("startIndicator", false);
            charAnimator.SetBool("stopIndicator", true);
        }
    }

    public IEnumerator FadeoutMiniGame(int scene)
    {
        playerControl = false;
        transition.SetBool("fadeout", true);

        yield return new WaitForSeconds(1.2f);

        transition.SetBool("fadeout", false);

        SceneManager.LoadScene(scene);
    }

    public IEnumerator Explosion()
    {
        playerControl = false;
        cameraAnimator.SetBool("cameraTest", true);
        lineNum++;
        ShowDialogue();
        UpdateUI();
        yield return new WaitForSeconds(4);
        playerControl = true;
    }

    public IEnumerator DelayUser()
    {
        playerControl = false;
        yield return new WaitForSeconds(0.5f);
        playerControl = true;
    }
}