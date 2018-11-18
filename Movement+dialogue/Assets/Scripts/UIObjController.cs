using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIObjController : MonoBehaviour, IPointerClickHandler{
    public Canvas Obj;
    public Canvas Myself;

    public void OnPointerClick(PointerEventData eventData)
    {
        Myself.gameObject.SetActive(false);
        Obj.gameObject.SetActive(true);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Myself.gameObject.SetActive(false);
            Obj.gameObject.SetActive(true);
        }
    }
}
