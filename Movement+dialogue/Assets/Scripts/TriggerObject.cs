using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour {
    public GameObject rg;
    public GameObject Myself;
    public bool active = false;
    public ObjectiveController OC;
    public int chapter;
    public int task;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("MC"))
        {
            active = true;
            rg.transform.position=this.transform.position;
            rg.SetActive(true);
            
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("MC"))
        {
            active = false;
            rg.SetActive(false);
        }
    }
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return) && active)
        {
            Myself.SetActive(false);
            rg.SetActive(false);
            OC.MissionComplete(chapter, task);
        }
    }
}
