using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour {

    public static SoundManager Instance = null;

	public SoundEventData _soundEventData;

    public AudioMixer _audioMixer;
    public string[] _events;
    public string _eventTextField;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

    }
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /*-------------------------------*/

	public string[] GetAudiomixerGroups(AudioMixer a = null)
    {
		
		AudioMixer am = a;
		if(am == null)
			am = _audioMixer;
        List<string> listAudioMixers = new List<string>();
		foreach (AudioMixerGroup amg in am.FindMatchingGroups(string.Empty))
        {
            listAudioMixers.Add(amg.name);
        }
        return listAudioMixers.ToArray();      
    }
	public virtual void Coucou()
	{
		Debug.Log("coucou");
	}
    public void SaveEventLog()
    {
        
    }

    /*-------------------------------*/

    public void AddObject()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.parent = gameObject.transform;
        GameObject.DestroyImmediate(cube.GetComponent<BoxCollider>());
    }

    public string[] RegisterEvent(string ev, string[] eventList)
    {
        bool found = false;
        string[] evts = eventList;
        foreach (string e in evts)
        {
            if (e == ev)
            {
                found = true;
                break;
            }
        }
        if (!found)
        {
            System.Array.Resize(ref evts, evts.Length + 1);
            evts[evts.Length - 1] = ev;
        }
        return evts;
    }

    public void AddSoundComponent()
    {
        GameObject sc = new GameObject("SoundComponent");
        sc.transform.parent = transform;
        sc.AddComponent<SoundComponent>();
        //Debug.Log(_audioMixer.name);
    }
    public void PlaySound()
    {
 
    }
    public void PostEvent(string eventname,GameObject go=null)
    {
        GameObject g = go;
        if (g == null)
            g = Camera.main.gameObject;
        List<GameObject> gSources = new List<GameObject>();
        foreach(SoundEventListener _sc in gameObject.GetComponentsInChildren<SoundEventListener>())
        {
            Debug.Log(_sc._events[_sc._eventIndex]);
            if(_sc._events[_sc._eventIndex] == eventname)
            {
                gSources.Add(_sc.gameObject);
            }
        }
    }
}