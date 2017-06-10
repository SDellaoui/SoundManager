using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class SoundInstance : MonoBehaviour {

    AudioSource _audioSource;
    public GameObject _attachedGameObject;

    AudioSource _as;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        _audioSource.transform.position = _attachedGameObject.transform.position;
	}

    public void Init(AudioSource a)
    {
        _audioSource = new AudioSource();
        _audioSource = Instantiate(a) as AudioSource;
        _audioSource.transform.parent = _attachedGameObject.transform;
        _audioSource.transform.position = _attachedGameObject.transform.position;
        _audioSource.Play();
    }
}
