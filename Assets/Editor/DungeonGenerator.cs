using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RecursiveDungeon))]
public class DungeonGenerator : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        serializedObject.Update();
        RecursiveDungeon generator = (RecursiveDungeon)target;
        if (GUILayout.Button("GenerateMaze"))
        {
            generator.Build();
        }
        if (GUILayout.Button("Save"))
        {
            generator.SaveMap();
        }
        if (GUILayout.Button("LoadMap"))
        {
            generator.LoadMap();
        }
        if (GUILayout.Button("ResetMap"))
        {
            generator.ResetMap();
        }
        serializedObject.ApplyModifiedProperties();
    }
}
