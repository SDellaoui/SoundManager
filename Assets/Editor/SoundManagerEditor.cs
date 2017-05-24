using System.Collections;
using UnityEngine;
using UnityEditor;
using UnityEngine.Audio;

[CustomEditor(typeof(SoundManager))]
[CanEditMultipleObjects]
public class SoundManagerEditor : Editor {

    public Vector2 metrix;
    public AudioMixer audioMixer;
    // Use this for initialization
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        SoundManager sm = (SoundManager)target;
        sm._audioMixer = EditorGUILayout.ObjectField("AudioMixer", sm._audioMixer, GUILayoutOption,false);

        //sm._audioMixer = EditorGUILayout.IntField("Yolo", sm._audioMixer);
        if (GUILayout.Button("Add Object"))
            sm.AddObject();

    }
}
