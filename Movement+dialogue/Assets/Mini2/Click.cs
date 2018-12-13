using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Click : MonoBehaviour {
    public Text a1;
    public Text a2;
    public Text a3;
    public Text a4;
    public Text a5;
    public Text a6;
    public Text a7;
    public Text a8;
    private int curr = 0;
    private String[] s=new String[8];
    public GameObject elem1;
    public GameObject elem2;
    public GameObject elem3;
    public GameObject elem4;
    public GameObject elem5;
    public GameObject elem6;
    public GameObject elem7;
    public GameObject elem8;
    public GameObject ans1;
    public GameObject ans2;
    public GameObject ans3;
    public GameObject ans4;
    public GameObject ans5;
    public GameObject ans6;
    public GameObject ans7;
    public GameObject ans8;
	// Use this for initialization
	void Start () {
        int i = 0;
        for (i = 0; i < 8; i++)
        {
            s[i] = (i + 1).ToString();
        }
        textUpdate();
    }
	
	// Update is called once per frame
	void textUpdate () {
        a1.text = s[0];
        a2.text = s[1];
        a3.text = s[2];
        a4.text = s[3];
        a5.text = s[4];
        a6.text = s[5];
        a7.text = s[6];
        a8.text = s[7];
        if (curr == 8)
        {
            String answer = a1.text + a2.text + a3.text + a4.text + a5.text + a6.text + a7.text + a8.text;
            print(answer);
            if (answer == "Liu, C.-C.,& Chang, I.-C.(2016).Model of online game addiction: the role of computer-mediated communication motives.Telematics and Informatics,33,904–915.https://doi.org/10.1016/j.tele.2016.02.002")
                SceneManager.LoadScene(7);
        }
    }
    void shiftText(int num)
    {
        int i = 0;
            for (i = num; i < 7; i++)
            {
                if (s[i + 1] == "1" || s[i + 1] == "2" || s[i + 1] == "3" || s[i + 1] == "4" || s[i + 1] == "5" || s[i + 1] == "6" || s[i + 1] == "7" || s[i + 1] == "8")
                    break;
                else
                {
                    s[i] = s[i + 1];
                    s[i + 1] = (i + 2).ToString();
                }    
            }
    }
    public void answerClick1()
    {
        if (a1.text == "Model of online game addiction: the role of computer-mediated communication motives.")
        {
            elem1.SetActive(true);
        }
        else if (a1.text == "(2016).")
        {
            elem2.SetActive(true);
        }
        else if (a1.text == "904–915.")
        {
            elem3.SetActive(true);
        }
        else if (a1.text == "https://doi.org/10.1016/j.tele.2016.02.002")
        {
            elem4.SetActive(true);
        }
        else if (a1.text == "Liu, C.-C.,")
        {
            elem5.SetActive(true);
        }
        else if (a1.text == "& Chang, I.-C.")
        {
            elem6.SetActive(true);
        }
        else if (a1.text == "Telematics and Informatics,")
        {
            elem7.SetActive(true);
        }
        else if (a1.text == "33,")
        {
            elem8.SetActive(true);
        }
        else
            return;
        s[0] = "1";
        shiftText(0);
        curr--;
        textUpdate();
    }
    public void answerClick2()
    {
        if (a2.text == "Model of online game addiction: the role of computer-mediated communication motives.")
        {
            elem1.SetActive(true);
        }
        else if (a2.text == "(2016).")
        {
            elem2.SetActive(true);
        }
        else if (a2.text == "904–915.")
        {
            elem3.SetActive(true);
        }
        else if (a2.text == "https://doi.org/10.1016/j.tele.2016.02.002")
        {
            elem4.SetActive(true);
        }
        else if (a2.text == "Liu, C.-C.,")
        {
            elem5.SetActive(true);
        }
        else if (a2.text == "& Chang, I.-C.")
        {
            elem6.SetActive(true);
        }
        else if (a2.text == "Telematics and Informatics,")
        {
            elem7.SetActive(true);
        }
        else if (a2.text == "33,")
        {
            elem8.SetActive(true);
        }
        else
            return;
        s[1] = "2";
        shiftText(1);
        curr--;
        textUpdate();
    }
    public void answerClick3()
    {
        if (a3.text == "Model of online game addiction: the role of computer-mediated communication motives.")
        {
            elem1.SetActive(true);
        }
        else if (a3.text == "(2016).")
        {
            elem2.SetActive(true);
        }
        else if (a3.text == "904–915.")
        {
            elem3.SetActive(true);
        }
        else if (a3.text == "https://doi.org/10.1016/j.tele.2016.02.002")
        {
            elem4.SetActive(true);
        }
        else if (a3.text == "Liu, C.-C.,")
        {
            elem5.SetActive(true);
        }
        else if (a3.text == "& Chang, I.-C.")
        {
            elem6.SetActive(true);
        }
        else if (a3.text == "Telematics and Informatics,")
        {
            elem7.SetActive(true);
        }
        else if (a3.text == "33,")
        {
            elem8.SetActive(true);
        }
        else
            return;
        s[2] = "3";
        shiftText(2);
        curr--;
        textUpdate();
    }
    public void answerClick4()
    {
        if (a4.text == "Model of online game addiction: the role of computer-mediated communication motives.")
        {
            elem1.SetActive(true);
        }
        else if (a4.text == "(2016).")
        {
            elem2.SetActive(true);
        }
        else if (a4.text == "904–915.")
        {
            elem3.SetActive(true);
        }
        else if (a4.text == "https://doi.org/10.1016/j.tele.2016.02.002")
        {
            elem4.SetActive(true);
        }
        else if (a4.text == "Liu, C.-C.,")
        {
            elem5.SetActive(true);
        }
        else if (a4.text == "& Chang, I.-C.")
        {
            elem6.SetActive(true);
        }
        else if (a4.text == "Telematics and Informatics,")
        {
            elem7.SetActive(true);
        }
        else if (a4.text == "33,")
        {
            elem8.SetActive(true);
        }
        else
            return;
        s[3] = "4";
        shiftText(3);
        curr--;
        textUpdate();
    }
    public void answerClick5()
    {
        if (a5.text == "Model of online game addiction: the role of computer-mediated communication motives.")
        {
            elem1.SetActive(true);
        }
        else if (a5.text == "(2016).")
        {
            elem2.SetActive(true);
        }
        else if (a5.text == "904–915.")
        {
            elem3.SetActive(true);
        }
        else if (a5.text == "https://doi.org/10.1016/j.tele.2016.02.002")
        {
            elem4.SetActive(true);
        }
        else if (a5.text == "Liu, C.-C.,")
        {
            elem5.SetActive(true);
        }
        else if (a5.text == "& Chang, I.-C.")
        {
            elem6.SetActive(true);
        }
        else if (a5.text == "Telematics and Informatics,")
        {
            elem7.SetActive(true);
        }
        else if (a5.text == "33,")
        {
            elem8.SetActive(true);
        }
        else
            return;
        s[4] = "5";
        shiftText(4);
        curr--;
        textUpdate();
    }
    public void answerClick6()
    {
        if (a6.text == "Model of online game addiction: the role of computer-mediated communication motives.")
        {
            elem1.SetActive(true);
        }
        else if (a6.text == "(2016).")
        {
            elem2.SetActive(true);
        }
        else if (a6.text == "904–915.")
        {
            elem3.SetActive(true);
        }
        else if (a6.text == "https://doi.org/10.1016/j.tele.2016.02.002")
        {
            elem4.SetActive(true);
        }
        else if (a6.text == "Liu, C.-C.,")
        {
            elem5.SetActive(true);
        }
        else if (a6.text == "& Chang, I.-C.")
        {
            elem6.SetActive(true);
        }
        else if (a6.text == "Telematics and Informatics,")
        {
            elem7.SetActive(true);
        }
        else if (a6.text == "33,")
        {
            elem8.SetActive(true);
        }
        else
            return;
        s[5] = "6";
        shiftText(5);
        curr--;
        textUpdate();
    }
    public void answerClick7()
    {
        if (a7.text == "Model of online game addiction: the role of computer-mediated communication motives.")
        {
            elem1.SetActive(true);
        }
        else if (a7.text == "(2016).")
        {
            elem2.SetActive(true);
        }
        else if (a7.text == "904–915.")
        {
            elem3.SetActive(true);
        }
        else if (a7.text == "https://doi.org/10.1016/j.tele.2016.02.002")
        {
            elem4.SetActive(true);
        }
        else if (a7.text == "Liu, C.-C.,")
        {
            elem5.SetActive(true);
        }
        else if (a7.text == "& Chang, I.-C.")
        {
            elem6.SetActive(true);
        }
        else if (a7.text == "Telematics and Informatics,")
        {
            elem7.SetActive(true);
        }
        else if (a7.text == "33,")
        {
            elem8.SetActive(true);
        }
        else
            return;
        s[6] = "7";
        shiftText(6);
        curr--;
        textUpdate();
    }
    public void answerClick8()
    {
        if (a8.text == "Model of online game addiction: the role of computer-mediated communication motives.")
        {
            elem1.SetActive(true);
        }
        else if (a8.text == "(2016).")
        {
            elem2.SetActive(true);
        }
        else if (a8.text == "904–915.")
        {
            elem3.SetActive(true);
        }
        else if (a8.text == "https://doi.org/10.1016/j.tele.2016.02.002")
        {
            elem4.SetActive(true);
        }
        else if (a8.text == "Liu, C.-C.,")
        {
            elem5.SetActive(true);
        }
        else if (a8.text == "& Chang, I.-C.")
        {
            elem6.SetActive(true);
        }
        else if (a8.text == "Telematics and Informatics,")
        {
            elem7.SetActive(true);
        }
        else if (a8.text == "33,")
        {
            elem8.SetActive(true);
        }
        else
            return;
        s[7] = "8";
        shiftText(7);
        curr--;
        textUpdate();
    }
    public void elementClick1()
    {
        if (curr < 8)
        {
            s[curr] = "Model of online game addiction: the role of computer-mediated communication motives.";
            curr++;
            elem1.SetActive(false);
            textUpdate();
        }
    }
    public void elementClick2()
    {
        if (curr < 8)
        {
            s[curr] = "(2016).";
            curr++;
            elem2.SetActive(false);
            textUpdate();
        }
    }
    public void elementClick3()
    {
        if (curr < 8)
        {
            s[curr] = "904–915.";
            curr++;
            elem3.SetActive(false);
            textUpdate();
        }
    }
    public void elementClick4()
    {
        if (curr < 8)
        {
            s[curr] = "https://doi.org/10.1016/j.tele.2016.02.002";
            curr++;
            elem4.SetActive(false);
            textUpdate();
        }
    }
    public void elementClick5()
    {
        if (curr < 8)
        {
            s[curr] = "Liu, C.-C.,";
            curr++;
            elem5.SetActive(false);
            textUpdate();
        }
    }
    public void elementClick6()
    {
        if (curr < 8)
        {
            s[curr] = "& Chang, I.-C.";
            curr++;
            elem6.SetActive(false);
            textUpdate();
        }
    }
    public void elementClick7()
    {
        if (curr < 8)
        {
            s[curr] = "Telematics and Informatics,";
            curr++;
            elem7.SetActive(false);
            textUpdate();
        }
    }
    public void elementClick8()
    {
        if (curr < 8)
        {
            s[curr] = "33,";
            curr++;
            elem8.SetActive(false);
            textUpdate();
        }
    }
}
