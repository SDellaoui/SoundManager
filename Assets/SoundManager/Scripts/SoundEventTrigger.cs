using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEventTrigger : MonoBehaviour {

	public string[] _events;
    public int _eventIndex = 0;
	// Use this for initialization
	void Start () {
        SoundManager.Instance.PostEvent(_events[_eventIndex], gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
