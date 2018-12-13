﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform map1;
    public Transform map2;
    public Transform map3;
    public Transform map4;
    public Transform map5;
    public Transform map6;
    public Transform map7;
    public Transform map8;
    public Transform map9;
    public MCControl MC;
    // Use this for initialization
    void Awake () {
        //MC = GameObject.FindObjectOfType<MCControl>();
        print(MC.stage);
    }
	
	// Update is called once per frame
	void LateUpdate () {
        if (MC.stage == 1) 
            transform.position = new Vector3(map1.position.x, map1.position.y, -10f);
        else if(MC.stage == 2) 
            transform.position = new Vector3(map2.position.x, map2.position.y, -10f);
        else if(MC.stage == 3){
            if(MC.rg.position.x < map3.position.x-4)
                transform.position = new Vector3(map3.position.x-4, map3.position.y, -10f);
            else if(MC.rg.position.x > map3.position.x + 4)
                transform.position = new Vector3(map3.position.x+4, map3.position.y, -10f);
            else
                transform.position = new Vector3(MC.rg.position.x, map3.position.y, -10f);
        }else if (MC.stage == 4)
            transform.position = new Vector3(map4.position.x, map4.position.y, -10f);
        else if(MC.stage == 5)
            transform.position = new Vector3(map5.position.x, map5.position.y, -10f);
        else if (MC.stage == 6)
            transform.position = new Vector3(map6.position.x, map6.position.y, -10f);
        else if (MC.stage == 7)
            transform.position = new Vector3(map7.position.x, map7.position.y, -10f);
        else if (MC.stage == 8)
            transform.position = new Vector3(map8.position.x, map8.position.y, -10f);
        else
            transform.position = new Vector3(map9.position.x, map9.position.y, -10f);



    }
}
