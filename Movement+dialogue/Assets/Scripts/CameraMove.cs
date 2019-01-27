using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject map;

    public MCControl MC;
    // Use this for initialization
    void Awake () {
    }
	
	// Update is called once per frame
	void LateUpdate () {
        float x;
        float y;
        float offsetX = 15;
        float offsetY = 7f;
        if (MC.rg.position.x < map.transform.position.x - offsetX)
            x = map.transform.position.x - offsetX;
        else if (MC.rg.position.x > map.transform.position.x + offsetX)
            x = map.transform.position.x + offsetX;
        else
            x = MC.rg.position.x;

        if (MC.rg.position.y < map.transform.position.y- offsetY)
            y = map.transform.position.y - offsetY;
        else if (MC.rg.position.y > map.transform.position.y + offsetY)
            y = map.transform.position.y + offsetY;
        else
            y = MC.rg.position.y;

        transform.position = new Vector3(x, y, -10f);




    }
}
