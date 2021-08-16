using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ObjectPlacer))]
public class ObjectPlacerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        serializedObject.Update();
        ObjectPlacer ob = (ObjectPlacer)target;
        if (GUILayout.Button("PlaceBlueDiamonds"))
        {
            ob.PlaceBlueDiamonds();
        }
        if (GUILayout.Button("PlaceGreenDiamonds"))
        {
            ob.PlaceGreenDiamonds();
        }
        if (GUILayout.Button("PlaceGoldCoins"))
        {
            ob.PlaceGoldCoins();
        }
        if (GUILayout.Button("PlacePinkDiamonds"))
        {
            ob.PlacePinkDiamonds();
        }
        if (GUILayout.Button("PlaceRocks"))
        {
            ob.PlaceRocks();
        }
        serializedObject.ApplyModifiedProperties();
    }
}
