using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SoundEventListener))]
[CanEditMultipleObjects]
public class SoundEventListenerEditor : Editor {

	public SoundEventListener _sndEvtListener;
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

		_sndEvtListener = (SoundEventListener)target;
		_sndEvtListener._events = _sndEvtData._events;
		_sndEvtListener._eventIndex = EditorGUILayout.Popup("Events List", _sndEvtListener._eventIndex, _sndEvtListener._events, EditorStyles.popup);

		serializedObject.ApplyModifiedProperties();
	}
}
