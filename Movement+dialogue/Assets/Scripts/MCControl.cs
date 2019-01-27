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
    public Trigger trigger;
    // Use this for initialization


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
