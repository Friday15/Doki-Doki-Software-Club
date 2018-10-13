using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TalkTalk : MonoBehaviour {

	public Text BText1;

	public Text BText2;

	public Text SText1;

	public Text SText2;

	public int _int = 1;

	public GameObject IstChoice;

	public GameObject IIndChoice;

	public GameObject nextbutton;


	/// CHOICE TIME ///

	public void F()
	{
		BText1.text = "Yeah Sure Man!";
		SText1.text = "Alan";
		
		BText2.text = "";
		SText2.text = "";

		_int = 100;

		IstChoice.SetActive(false);
		IIndChoice.SetActive(false);
		nextbutton.SetActive(true);

	}

	public void S()
	{
		BText1.text = "Sorry dude, I've promised my sister that I'll be in her show this Saturday.";
		SText1.text = "Alan";
		
		BText2.text = "";
		SText2.text = "";

		_int = 99;

		nextbutton.SetActive(true);
		IstChoice.SetActive(false);
		IIndChoice.SetActive(false);
	}

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _int = _int + 1;

            ///////////	///// ALAN ////////////

            if (_int == 2)
            {
                BText1.text = "Hi";
                SText1.text = "Alan";

                BText2.text = "";
                SText2.text = "";

            }


            else if (_int == 4)
            {
                BText1.text = "How was the party last night?";
                SText1.text = "Alan";

                BText2.text = "";
                SText2.text = "";

            }

            else if (_int == 6)
            {
                BText1.text = "Great. And how was Mindy?";
                SText1.text = "Alan";

                BText2.text = "";
                SText2.text = "";

            }

            ///////////// STEVE //////////////

            else if (_int == 3)
            {
                BText1.text = "";
                SText1.text = "";

                BText2.text = "Hey Alan";
                SText2.text = "Steve";

            }

            else if (_int == 5)
            {
                BText1.text = "";
                SText1.text = "";

                BText2.text = "It was amazing! I met Cindy for the first time after so many years.";
                SText2.text = "Steve";

            }

            else if (_int == 7)
            {
                BText1.text = "";
                SText1.text = "";

                BText2.text = "Mindy was fine too. Hey, you wanna come to the hiking we're organizing on Saturday?";
                SText2.text = "Steve";
                nextbutton.SetActive(false);
                IstChoice.SetActive(true);
                IIndChoice.SetActive(true);

            }

            /// After Choices ///
            else if (_int == 100)
            {
                BText1.text = "";
                SText1.text = "";

                BText2.text = "It's okay dude maybe some other time.";
                SText2.text = "Steve";
                nextbutton.SetActive(true);
                _int = 119;

            }

            else if (_int == 101)
            {
                BText1.text = "";
                SText1.text = "";

                BText2.text = "Awesome! See you on Saturday.";
                SText2.text = "Steve";
                _int = 119;

                nextbutton.SetActive(true);
            }

            else if (_int == 120)
            {
                BText1.text = "";
                SText1.text = "";

                BText2.text = "We Left. The End.";
                SText2.text = "";
                _int = 119;
            }
        }
    }
}

