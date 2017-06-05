using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SoundEventTrigger))]
[CanEditMultipleObjects]
public class SoundEventTriggerEditor : Editor {

	public SoundEventTrigger _sndEvtTrigger;
	public SoundEventData _sndEvtData;

	void OnEnable()
	{
		/*
		//_sndEvtData = ScriptableObject.CreateInstance<SoundEventData>();
		if (_sndEvtData == null)
			_sndEvtData = Object.FindObjectOfType<SoundEventData>();      
		// then instantiate if needed
		if (_sndEvtData == null)
			_sndEvtData = ScriptableObject.CreateInstance<SoundEventData>();
		Debug.Log(_sndEvtData._events[0]);
		*/
		_sndEvtData = Resources.Load<SoundEventData>("EventsData");
	}
	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		_sndEvtTrigger = (SoundEventTrigger)target;
		_sndEvtTrigger._events = _sndEvtData._events;
        _sndEvtTrigger._eventIndex = EditorGUILayout.Popup("Events List", _sndEvtTrigger._eventIndex, _sndEvtTrigger._events, EditorStyles.popup);

		serializedObject.ApplyModifiedProperties();
	}
}
