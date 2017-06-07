using System.Collections;
using UnityEngine;
using UnityEditor;
using UnityEngine.Audio;

[CustomEditor(typeof(SoundComponent))]
[CanEditMultipleObjects]
public class SoundComponentEditor : Editor
{
    public bool m_loop = false;
    bool m_playOnAwake = false;

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
		sc._buses = sc.GetAudiomixerGroups(_sndEventData._currentAudioMixer);
        sc._busIndex = EditorGUILayout.Popup("BUS", sc._busIndex, sc._buses, EditorStyles.popup);
        sc._audioClip = (AudioClip)EditorGUILayout.ObjectField("AudioClip", sc._audioClip, typeof(AudioClip), true);
        sc._loop = EditorGUILayout.Toggle("Loop", m_loop);
        sc._playOnAwake = EditorGUILayout.Toggle("PlayOnAwake", m_playOnAwake);

    }
    private void OnGUI()
    {
        Debug.Log("OnScreenHUI");
    }
}
