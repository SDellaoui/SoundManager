using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundComponent : SoundManager{


    public AudioSource _audioSource;
    public AudioClip _audioClip;
    public bool _loop = false;
    public bool _playOnAwake = false;

	// Use this for initialization
    void Awake()
    {
        /*
        _audioSource = new AudioSource();
        _audioSource.clip = _audioClip;
        _audioSource.loop = _loop;
        _audioSource.playOnAwake = _playOnAwake;
         * */
    }
	void Start()
    {
        PlaySound();
        PlaySound(gameObject);
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
