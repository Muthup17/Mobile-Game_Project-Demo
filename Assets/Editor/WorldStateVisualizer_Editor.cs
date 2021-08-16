using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GOAP_WorldStateVisualizer))]
[CanEditMultipleObjects]
public class WorldStateVisualizer_Editor : Editor
{
    private void OnEnable()
    {

    }
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        serializedObject.Update();
        GOAP_WorldStateVisualizer world = (GOAP_WorldStateVisualizer)target;

        GUILayout.Label("WorldStates: ");
        if (world.gWorld != null)
        {
            foreach (KeyValuePair<string, int> ws in world.gWorld.World.GetStates)
            {
                GUILayout.Label("=====  " + ws.Key + "    " + ws.Value.ToString());
            }
        }

        GUILayout.Label("Inventory: ");
        if(world.gWorld != null)
        {
            foreach (KeyValuePair<string, ResourceQueue> resource in world.gWorld.AllResources)
            {
                foreach (GameObject g in resource.Value.rQueue)
                {
                    if (g.tag != "")
                    {
                        GUILayout.Label("====  " + g.tag);
                    }
                    else
                    {
                        GUILayout.Label("====  " + g.name);
                    }
                }

            }
        }
        serializedObject.ApplyModifiedProperties();
    }
}
