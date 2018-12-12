<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GenderControl : MonoBehaviour, IPointerClickHandler {
    public Image thisG;
    public Image oval;
    public Image Other;
    public Image Othero;
    public GenderControl OtherG;
    public bool chosen;

    public void OnPointerClick(PointerEventData eventData)
    {
        Other.color =  new Color32(128, 128, 128, 255);
        Othero.color = new Color32(128, 128, 128, 255);
        thisG.color = new Color32(255, 255, 255, 255);
        oval.color = new Color32(255, 255, 255, 255);
        chosen = true;
        OtherG.makefalse();
    }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void makefalse()
    {
        chosen = false;
    }
    public bool getChosen()
    {
        return chosen;
    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GenderControl : MonoBehaviour, IPointerClickHandler {
    public Image thisG;
    public Image oval;
    public Image Other;
    public Image Othero;
    public GenderControl OtherG;
    public bool chosen;

    public void OnPointerClick(PointerEventData eventData)
    {
        Other.color =  new Color32(128, 128, 128, 255);
        Othero.color = new Color32(128, 128, 128, 255);
        thisG.color = new Color32(255, 255, 255, 255);
        oval.color = new Color32(255, 255, 255, 255);
        chosen = true;
        OtherG.makefalse();
    }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void makefalse()
    {
        chosen = false;
    }
    public bool getChosen()
    {
        return chosen;
    }
}
>>>>>>> cccb023de4e5423beb17df26bc94ce3569286f4a
