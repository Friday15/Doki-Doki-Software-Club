using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCControl : MonoBehaviour {
    public float Mspeed = 5f;
    public int stage;
    public Rigidbody2D rg;
    public Transform A1;
    public Transform B1;
    public Transform A2;
    public Transform B2;
    public Transform A3;
    public Transform B3;
    public Transform C3;
    public Transform D3;
    public Transform A4;
    public Transform B4;
    public Transform C4;
    public Transform D4;
    public Transform A5;
    public Transform B5;
    //A1 <-> A2
    //B1 <-> A3
    //B2 <-> D3
    //B3 <-> A4
    //C3 <-> B4
    //C4 <-> A5
    //D4 <-> B5 
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float hmove = Input.GetAxis("Horizontal");
        float vmove = Input.GetAxis("Vertical");
        rg.velocity = new Vector2(hmove*Mspeed, vmove*Mspeed);
        //area 1 moves
        if (rg.position.x > A1.position.x&& stage == 1) {
            rg.position = A2.position;
            stage = 2;
            }
        if (rg.position.y < B1.position.y && rg.position.x < B1.position.x && stage == 1)
        {
            rg.position = A3.position;
            stage = 3;
        }
        //area 2 moves
        if (rg.position.x < A2.position.x && stage == 2)
        {
            rg.position = A1.position;
            stage = 1;
        }
        if (rg.position.y < B2.position.y && rg.position.x < B2.position.x && stage == 2)
        {
            rg.position = D3.position;
            stage = 3;
        }
        //area 3 moves
        if (rg.position.x < A3.position.x && rg.position.y > A3.position.y && stage == 3)
        {
            rg.position = B1.position;
            stage = 1;
        }
        if ((rg.position.x>B3.position.x-1.5f&& rg.position.x < B3.position.x + 1.5f) &&rg.position.y < B3.position.y && stage == 3)
        {
            rg.position = A4.position;
            stage = 4;
        }
        if (rg.position.y < C3.position.y && rg.position.x > C3.position.x && stage == 3)
        {
            rg.position = B4.position;
            stage = 4;
        }
        if (rg.position.x > D3.position.x && stage == 3)
        {
            rg.position = B2.position;
            stage = 2;
        }
        //area 4 moves
        if ((rg.position.x > A4.position.x - 1.5f && rg.position.x < A4.position.x + 1.5f) && rg.position.y > A4.position.y && stage == 4)
        {
            rg.position = B3.position;
            stage = 3;
        }
        if ((rg.position.x > B4.position.x - 1.5f && rg.position.x < B4.position.x + 1.5f) && rg.position.y > B4.position.y && stage == 4)
        {
            rg.position = C3.position;
            stage = 3;
        }
        if ((rg.position.y > C4.position.y - 1.5f && rg.position.y < C4.position.y + 1.5f) && rg.position.x > C4.position.x && stage == 4)
        {
            rg.position = A5.position;
            stage = 5;
        }
        if ((rg.position.y > D4.position.y - 1.5f && rg.position.y < D4.position.y + 1.5f) && rg.position.x > D4.position.x && stage == 4)
        {
            rg.position = B5.position;
            stage = 5;
        }
        //area 5 moves
        if ((rg.position.y > A5.position.y - 1.5f && rg.position.y < A5.position.y + 1.5f) && rg.position.x < A5.position.x && stage == 5)
        {
            rg.position = C4.position;
            stage = 4;
        }
        if ((rg.position.y > B5.position.y - 1.5f && rg.position.y < B5.position.y + 1.5f) && rg.position.x < B5.position.x && stage == 5)
        {
            rg.position = D4.position;
            stage = 4;
        }
    }
}
