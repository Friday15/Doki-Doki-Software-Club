<<<<<<< HEAD
<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickEvent : MonoBehaviour {
    public Image img;
	public Image baseColor;
    private Color clr;
    public void changeImage()
    {
        clr = new Color(197 / 255f, 40 / 255f, 61 / 255f, 255 / 255f);
        if (img.GetComponent<Image>().color == clr)
            img.GetComponent<Image>().color = baseColor.GetComponent<Image>().color;
        else
            img.GetComponent<Image>().color = clr;
        //img.gameObject.SetActive(false);
    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickEvent : MonoBehaviour {
    public Image img;
	public Image baseColor;
    private Color clr;
    public void changeImage()
    {
        clr = new Color(197 / 255f, 40 / 255f, 61 / 255f, 255 / 255f);
        if (img.GetComponent<Image>().color == clr)
            img.GetComponent<Image>().color = baseColor.GetComponent<Image>().color;
        else
            img.GetComponent<Image>().color = clr;
        //img.gameObject.SetActive(false);
    }
}
>>>>>>> parent of cccb023... jalter nut
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickEvent : MonoBehaviour {
    public Image img;
	public Image baseColor;
    private Color clr;
    public void changeImage()
    {
        clr = new Color(197 / 255f, 40 / 255f, 61 / 255f, 255 / 255f);
        if (img.GetComponent<Image>().color == clr)
            img.GetComponent<Image>().color = baseColor.GetComponent<Image>().color;
        else
            img.GetComponent<Image>().color = clr;
        //img.gameObject.SetActive(false);
    }
}
>>>>>>> parent of cccb023... jalter nut
