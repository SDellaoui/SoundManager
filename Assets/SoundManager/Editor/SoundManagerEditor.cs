using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Audio;

[CustomEditor(typeof(SoundManager))]
[CanEditMultipleObjects]
public class SoundManagerEditor : Editor {

    private SoundManager sm;

    public string[] _events;
    public int _eventIndex = 0;
    public SoundEventData _soundEventData;

    /*
    private SerializedObject m_SoundManagerObject;
    private SerializedProperty m_audioMixer;
    */


    // Use this for initialization
    /*
    void OnEnable()
    {
        m_SoundManagerObject = new SerializedObject(target);
    }
    */
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        
        serializedObject.Update();
        this.InitSoundManagerEditor();
        serializedObject.ApplyModifiedProperties();
    }
    private void InitSoundManagerEditor()
    {
        //Init AudioMixer
        /*
        m_audioMixer = m_SoundManagerObject.FindProperty("_audioMixer");
        EditorGUILayout.PropertyField(m_audioMixer, new GUIContent("AudioMixer"), true);
        m_SoundManagerObject.ApplyModifiedProperties();
        */
        //GetTarget
        _soundEventData = Resources.Load<SoundEventData>("EventsData");
 
        sm = (SoundManager)target;
        sm._audioMixer = (AudioMixer)EditorGUILayout.ObjectField("AudioMixer", sm._audioMixer, typeof(AudioMixer),true);
        if (GUILayout.Button("AddComponent"))
            sm.AddSoundComponent();

        GUILayout.Space(10f);

        sm._eventTextField = EditorGUILayout.TextField("event", sm._eventTextField);
        sm._events = _soundEventData._events;
        _eventIndex = EditorGUILayout.Popup("Events List", _eventIndex, sm._events, EditorStyles.popup);

        if (GUILayout.Button("Add Event"))
        {
            sm._events = sm.RegisterEvent(sm._eventTextField, sm._events);
            _soundEventData._events = sm._events;
            sm._eventTextField = "";
            GUI.FocusControl("Add Event");
        }
        
        if(GUILayout.Button("Delete Event"))
        {
            List<string> myList = new List<string>();

            int prevLength = myList.Count;

            myList.AddRange(sm._events);
            myList.RemoveAt(_eventIndex);
            sm._events = myList.ToArray();
            _soundEventData._events = sm._events;

            if(myList.Count > 0 && (_eventIndex - 1) >= 0)
                _eventIndex--;
        }
    }
    private void OnEnable()
    {
        /*
        _soundEventData = Resources.Load<SoundEventData>("EventData");
        Debug.Log(_soundEventData._events[0]);
         * */
    }
}
