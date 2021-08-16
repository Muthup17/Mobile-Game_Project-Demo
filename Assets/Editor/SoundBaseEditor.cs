using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SoundBase), true)]
public class SoundBaseEditor : Editor
{
    private AudioSource _source;
    private void OnEnable()
    {
        _source = EditorUtility.CreateGameObjectWithHideFlags("Audio_Sourece", HideFlags.HideAndDontSave, typeof(AudioSource)).GetComponent<AudioSource>();
    }

    public void OnDisable()
    {
        DestroyImmediate(_source.gameObject);
    }

    public override void OnInspectorGUI()
    {

        DrawDefaultInspector();

        EditorGUI.BeginDisabledGroup(serializedObject.isEditingMultipleObjects);
        if (GUILayout.Button("Preview"))
        {
            ((SoundBase)target).Play(_source);
        }
        EditorGUI.EndDisabledGroup();

    }
}
