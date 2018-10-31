using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnimatedText : MonoBehaviour
{
    //Time taken for each letter to appear (The lower it is, the faster each letter appear)
    public float letterPaused = 0f;
    //Message that will displays till the end that will come out letter by letter
    public string message;
    //Text for the message to display
    public Text textComp;

    public bool done = true;

    /*
    // Use this for initialization
    void Start()
    {
        //Get text component
        textComp = GetComponent<Text>();
        //Message will display will be at Text
        message = textComp.text;
        //Set the text to be blank first
        textComp.text = "";
        //Call the function and expect yield to return
        StartCoroutine(TypeText());
    }
    */

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
        done = true;
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
        print("THIS SHOULD BE WORKING REEEE");
    }

    IEnumerator TypeText()
    {
        //Split each char into a char array
        foreach (char letter in message.ToCharArray())
        {
            //Add 1 letter each
            textComp.text += letter;
            yield return 0;
            yield return new WaitForSeconds(letterPaused);
        }
        done = true;
        print("SHOULD PRINT AFTER STOPPING??");
    }

}