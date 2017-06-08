using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundComponent : SoundManager{

	public string _guID;

    public AudioSource _audioSource;
    public AudioClip _audioClip;

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
    public AudioSource GetAudioSource()
    {
        return _audioSource;
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
