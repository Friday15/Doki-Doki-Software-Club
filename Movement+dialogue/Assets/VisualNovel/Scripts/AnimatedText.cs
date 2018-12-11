using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedText : MonoBehaviour
{
    //Time taken for each letter to appear (The lower it is, the faster each letter appear)
    public float letterPaused = 0f;
    //Message that will displays till the end that will come out letter by letter
    public string message;
    //Text for the message to display
    public Text textComp;

    public int index;
    string regularString = "";
    public bool done = false;
    public bool cancel = false;
    public GameObject thingy;
    public Animator animator;
    
    // Use this for initialization
    void Start()
    {
        thingy = GameObject.Find("thingy");
        animator = GameObject.Find("GamePanel").GetComponent<Animator>();
        index = 0;
    }
    

    public void startAnim()
    {
        //Get text component
        textComp = GetComponent<Text>();
        //Message will display will be at Text
        message = textComp.text;
        //Set the text to be blank first
        textComp.text = "";

        //Call the function and expect yield to return
        StopAllCoroutines();
        done = false;
        StartCoroutine(TypeText());
    }

    public void Clear()
    {
        //Get text component
        textComp = GetComponent<Text>();
        //Message will display will be at Text
        message = textComp.text;
        //Set the text to be blank first
        textComp.text = "";
        //print("THIS SHOULD BE WORKING REEEE");
    }

    public bool checkWrap(string m, int i)
    {
        string nextWord = getNextWord(i);
        TextGenerationSettings generationSettings = textComp.GetGenerationSettings(textComp.rectTransform.rect.size);
        float originalHeight = textComp.cachedTextGeneratorForLayout.GetPreferredHeight(m, generationSettings);
        float newHeight = textComp.cachedTextGeneratorForLayout.GetPreferredHeight(m + " " + nextWord, generationSettings);

        print("INCOMPLETE MESSAGE     " + m);
        print("INDEX     " + i);
        print("MESSAGE + NEXTWORD       " + m + " " + nextWord);

        if (newHeight > originalHeight)
        {
            return true;
        }        

        return false;
    }

    public string getNextWord(int index)
    {
        char[] tempArray = message.ToCharArray();
        string nextWord = "";

        for(int i = this.index + 1; i < tempArray.Length; i++)
        {
            if (!char.IsWhiteSpace(tempArray[i]))
            {
                print("tempArray in getNextWord()    " + tempArray[i]);
                nextWord += tempArray[i];
            }
            else
            {
                print("NEXTWORD   " + nextWord);
                return nextWord;
            }
        }

        return nextWord;
    }
    IEnumerator TypeText()
    {
        //Split each char into a char array
        foreach (char letter in message.ToCharArray())
        {
            if (cancel)
                break;
            regularString += letter;
            string removeWhiteSpace = Regex.Replace(textComp.text, @"\t|\n|\r", " ");
            if (char.IsWhiteSpace(letter) && checkWrap(removeWhiteSpace, index))
            {
                print("UNWRAPPED");
                textComp.text += "\n";
                index++;
            }
            else
            {
                //Add 1 letter each
                textComp.text += letter;
                index++;
            }
            yield return 0;
            yield return new WaitForSeconds(letterPaused);
        }
        done = true;
        //cancel = true;
        textComp.text = message;
        print("MESSAGE COMPLETE");
        thingy.SetActive(true);
        animator.SetBool("stopIndicator", false);
        animator.SetBool("startIndicator", true);
        index = 0;
        regularString = "";
    }

}