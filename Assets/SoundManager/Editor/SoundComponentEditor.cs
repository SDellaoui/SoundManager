using System;
using System.Collections;
using UnityEngine;
using UnityEditor;
using UnityEngine.Audio;

[CustomEditor(typeof(SoundComponent))]
[CanEditMultipleObjects]
public class SoundComponentEditor : Editor
{
	SoundComponent sc;
	SoundEventData _sndEventData;

	void OnEnable()
	{
		sc = (SoundComponent)target;
		_sndEventData = Resources.Load<SoundEventData>("EventsData");
	}
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        this.InitSoundComponentEditor();
    }
    private void InitSoundComponentEditor()
    {
        //Setup UI
		if(sc._guID == "")
			sc._guID = Guid.NewGuid().ToString();
		EditorGUILayout.LabelField(sc._guID);
		sc._buses = sc.GetAudiomixerGroups(_sndEventData._currentAudioMixer);
        sc._busIndex = EditorGUILayout.Popup("BUS", sc._busIndex, sc._buses, EditorStyles.popup);
        sc._audioClip = (AudioClip)EditorGUILayout.ObjectField("AudioClip", sc._audioClip, typeof(AudioClip), true);


        //AudioSource
		AudioSource _as;
        if(sc.gameObject.GetComponent<AudioSource>() == null)
        {
            _as = sc.gameObject.AddComponent<AudioSource>();
        } else {
			_as = sc.gameObject.GetComponent<AudioSource>();
		}
        //sc._audioSource = sc.gameObject.GetComponent<AudioSource>();
        //sc._audioSource.outputAudioMixerGroup = _sndEventData._currentAudioMixer.FindMatchingGroups(string.Empty)[sc._busIndex];
        //sc._audioSource.clip = sc._audioClip;
		_as.outputAudioMixerGroup = _sndEventData._currentAudioMixer.FindMatchingGroups(string.Empty)[sc._busIndex];
		sc._audioSource = _as;


    }
    private void OnGUI()
    {
        Debug.Log("OnScreenHUI");
    }
}
