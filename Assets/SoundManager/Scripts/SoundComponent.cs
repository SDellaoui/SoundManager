﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundComponent : SoundManager{


    public AudioSource _audioSource;
    public AudioClip _audioClip;
    public bool _loop = false;
    public bool _playOnAwake = false;

    public int _busIndex = 0;
    public string[] _buses;


	// Use this for initialization
    void Awake()
    {
		
    }
	void Start()
    {

    }
	// Update is called once per frame
	void Update () {
		
	}
    public void PlaySound()
    {
        Debug.Log("PlaySound");
    }
    public void PlaySound(GameObject go)
    {
        Debug.Log("zoeirz");
    }
}
