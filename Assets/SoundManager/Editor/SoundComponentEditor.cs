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

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        this.InitSoundComponentEditor();
    }
    private void InitSoundComponentEditor()
    {
        SoundComponent sc = (SoundComponent)target;
        sc._busIndex = EditorGUILayout.Popup("Events List", sc._busIndex, sc.GetAudiomixerGroups(), EditorStyles.popup);
        sc._audioClip = (AudioClip)EditorGUILayout.ObjectField("AudioClip", sc._audioClip, typeof(AudioClip), true);
        sc._loop = EditorGUILayout.Toggle("Loop", m_loop);
        sc._playOnAwake = EditorGUILayout.Toggle("PlayOnAwake", m_playOnAwake);

    }
    private void OnGUI()
    {
        Debug.Log("OnScreenHUI");
    }
}
