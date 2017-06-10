using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour {

	public List<object> _componentsList;

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
		_componentsList = new List<object>();
		_componentsList.Add(new SoundComponent());

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
	public void PlaySound(AudioMixer a, GameObject g)
    {
		
    }
    public void PostEvent(string eventname,GameObject go=null)
    {
        GameObject g = go;
        if (g == null)
            g = Camera.main.gameObject;
        List<GameObject> gSources = new List<GameObject>();
        Debug.Log(gameObject.name);
        foreach(SoundEventListener _sc in gameObject.GetComponentsInChildren<SoundEventListener>())
        {
            if(_sc._events[_sc._eventIndex] == eventname)
            {
				List<object> goAndComponent = new List<object>();
                gSources.Add(_sc.gameObject);
            }
        }
        foreach(GameObject gos in gSources)
        {
            GameObject soundInstance = new GameObject("AudioSource");
            soundInstance.transform.parent = gos.transform;
            soundInstance.transform.position = g.transform.position;
            SoundInstance inst = soundInstance.AddComponent<SoundInstance>();
            inst._attachedGameObject = g;
            inst.Init(gos.GetComponent<AudioSource>());
            /*
            AudioSource _as = soundInstance.AddComponent<AudioSource>();
            AudioSource parentAS = gos.GetComponent<AudioSource>();
            FieldInfo[] fields = parentAS.GetType().GetFields();
            foreach(FieldInfo f in fields)
            {
                f.SetValue(_as, f.GetValue(parentAS));
                Debug.Log(f);
            }
            /*
			foreach(object obj in _componentsList)
			{
				System.Type _type = obj.GetType();
				if(_type == typeof(SoundComponent))
				{
                    SoundComponent comp = g.AddComponent<SoundComponent>();
					SoundComponent component = gos.GetComponent(_type) as SoundComponent;
					Debug.Log(component._audioSource.clip.name);
					//TODO : Utilise les réflextions gros trou de balle
					FieldInfo[] fInfo = _type.GetFields();
                    foreach(FieldInfo field in fInfo){
                        field.SetValue(comp,field.GetValue(component));
                    }

					break;
				}
			}
			AudioSource audioSource = gos.GetComponent<AudioSource>();
            if(audioSource.loop == false)
            {
				Debug.Log(audioSource.clip);
				AudioSource _as = g.AddComponent<AudioSource>();
				_as = audioSource;
				_as.Play();

            }
    		*/
        }
    }
}