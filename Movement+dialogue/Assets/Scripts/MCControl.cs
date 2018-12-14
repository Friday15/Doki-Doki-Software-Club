using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCControl : MonoBehaviour
{
    public float Mspeed = 5f;
    public int stage;
    public Rigidbody2D rg;
    public SpriteRenderer sr;
    public Sprite Other;
    //0
    public Transform A1;
    public Transform B1;
    //2
    public Transform A2;
    public Transform B2;
    //4
    public Transform A3;
    public Transform B3;
    public Transform C3;
    public Transform D3;
    //8
    public Transform A4;
    public Transform B4;
    public Transform C4;
    public Transform D4;
    //12
    public Transform A5;
    public Transform B5;
    public Transform C5;
    //15
    public Transform A6;
    public Transform B6;
    //17
    public Transform A7;
    public Transform B7;
    //19
    public Transform A8;
    public Transform B8;
    //21
    public Transform A9;
    public Trigger trigger;
    //public Conversation conv;
    //0 - 2
    //1 - 4 
    //3 - 7
    //5 - 8
    //6 - 9
    //10 - 12
    //11 - 13
    // Use this for initialization

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("arrow"))
        {
            rg.position = new Vector2(A2.position.x + 1, A2.position.y);
            stage = 2;
        }
        if (col.gameObject.name.Equals("arrow (1)"))
        {
            rg.position = new Vector2(A3.position.x + 1, A3.position.y);
            stage = 3;
        }
        if (col.gameObject.name.Equals("arrow (2)"))
        {
            rg.position = new Vector2(A1.position.x - 1, A1.position.y);
            stage = 1;
        }
        if (col.gameObject.name.Equals("arrow (3)"))
        {
            rg.position = new Vector2(D3.position.x - 1, D3.position.y);
            stage = 3;
        }
        if (col.gameObject.name.Equals("arrow (4)"))
        {
            rg.position = new Vector2(B1.position.x + 1, B1.position.y);
            stage = 1;
        }
        if (col.gameObject.name.Equals("arrow (5)"))
        {
            rg.position = new Vector2(A4.position.x, A4.position.y - 1);
            stage = 4;
        }
        if (col.gameObject.name.Equals("arrow (6)"))
        {
            rg.position = new Vector2(B4.position.x, B4.position.y - 1);
            stage = 4;
        }
        if (col.gameObject.name.Equals("arrow (7)"))
        {
            rg.position = new Vector2(B2.position.x + 1, B2.position.y + 1);
            stage = 2;
        }
        if (col.gameObject.name.Equals("arrow (8)"))
        {
            rg.position = new Vector2(B3.position.x, B3.position.y + 1);
            stage = 3;
        }
        if (col.gameObject.name.Equals("arrow (9)"))
        {
            rg.position = new Vector2(C3.position.x, C3.position.y + 1);
            stage = 3;
        }
        if (col.gameObject.name.Equals("arrow (10)"))
        {
            rg.position = new Vector2(A5.position.x + 1, A5.position.y);
            stage = 5;
        }
        if (col.gameObject.name.Equals("arrow (11)"))
        {
            rg.position = new Vector2(B5.position.x + 1, B5.position.y);
            stage = 5;
        }
        if (col.gameObject.name.Equals("arrow (12)"))
        {
            rg.position = new Vector2(C4.position.x - 1, C4.position.y);
            stage = 4;
        }
        if (col.gameObject.name.Equals("arrow (13)"))
        {
            rg.position = new Vector2(D4.position.x - 1, D4.position.y);
            stage = 4;
        }
        if (col.gameObject.name.Equals("arrow (14)"))
        {
            rg.position = new Vector2(A6.position.x, A6.position.y + 1);
            stage = 6;
        }
        if (col.gameObject.name.Equals("arrow (15)"))
        {
            rg.position = new Vector2(C5.position.x - 0.5f, C5.position.y - 1);
            stage = 5;
        }
        if (col.gameObject.name.Equals("arrow (16)"))
        {
            rg.position = new Vector2(A7.position.x, A7.position.y + 1);
            stage = 7;
        }
        if (col.gameObject.name.Equals("arrow (17)"))
        {
            rg.position = new Vector2(B6.position.x, B6.position.y - 1);
            stage = 6;
        }
        if (col.gameObject.name.Equals("arrow (18)"))
        {
            rg.position = new Vector2(A8.position.x, A8.position.y + 1);
            stage = 8;
        }
        if (col.gameObject.name.Equals("arrow (19)"))
        {
            rg.position = new Vector2(B7.position.x, B7.position.y - 1);
            stage = 7;
        }
        if (col.gameObject.name.Equals("arrow (20)"))
        {
            rg.position = new Vector2(A9.position.x, A9.position.y + 1);
            stage = 9;
        }
        if (col.gameObject.name.Equals("arrow (21)"))
        {
            rg.position = new Vector2(B8.position.x, B8.position.y - 1);
            stage = 8;
        }
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("gender"))
        {
            if (PlayerPrefs.GetInt("gender") == 2)
                sr.sprite = Other;
        }
        if (PlayerPrefs.HasKey("x")&& PlayerPrefs.HasKey("y"))
            rg.position = new Vector2(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"));
        
        if (PlayerPrefs.HasKey("stage"))
            stage = PlayerPrefs.GetInt("stage");

        
    }

    // Update is called once per frame
    void Update()
    {
        float hmove = Input.GetAxis("Horizontal");
        float vmove = Input.GetAxis("Vertical");
        if (trigger.isConversing == 0)
            rg.velocity = new Vector2(hmove * Mspeed, vmove * Mspeed);
        else
            rg.Sleep();
        PlayerPrefs.SetFloat("x", rg.position.x);
        PlayerPrefs.SetFloat("y", rg.position.y);
        PlayerPrefs.SetInt("stage", stage);

    }
}
