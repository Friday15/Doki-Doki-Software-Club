﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
    public AudioSource Sound;
    public AudioClip Claps;
    public AudioClip Notes;
    public AudioClip Correct;
    public AudioClip Wrong;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void PlaySound()
    {
        Sound.clip = Claps;
        Sound.Play();
    }
    public void PlayNotes()
    {
        Sound.clip = Notes;
        Sound.Play();
    }

    public void PlayCorrect()
    {
        Sound.clip = Correct;
        Sound.Play();
    }

    public void PlayWrong()
    {
        Sound.clip = Wrong;
        Sound.Play();
    }
}
