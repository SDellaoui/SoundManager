using UnityEngine;
using UnityEditor;

public class EventDataAsset
{
    [MenuItem("Assets/Create/SoundEventData")]
    public static void CreateAsset()
    {
        ScriptableObjectUtility.CreateAsset<SoundEventData>();
    }
}