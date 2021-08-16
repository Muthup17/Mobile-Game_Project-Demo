using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GOAP_AgentVisualiser))]
[CanEditMultipleObjects]
public class GoapAgent_Editor : Editor
{
    private void OnEnable()
    {
        
    }
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        serializedObject.Update();

        GOAP_AgentVisualiser agent = (GOAP_AgentVisualiser)target;
        GUILayout.Label("Name: " + agent.name);
        if(agent.gameObject.GetComponent<GOAP_Agent>().currentGoal != null)
        {
            GUILayout.Label("Current Goal: " + agent.gameObject.GetComponent<GOAP_Agent>().currentGoal.sGoals);
        }
        GUILayout.Label("Current Action: " + agent.gameObject.GetComponent<GOAP_Agent>().currentAction);
        GUILayout.Label("Actions: ");
        foreach (GOAP_Action a in agent.gameObject.GetComponent<GOAP_Agent>().actions)
        {
            string pre = "";
            string eff = "";

            foreach (KeyValuePair<string, int> p in a.preConditions)
                pre += p.Key + ", ";
            foreach (KeyValuePair<string, int> e in a.effects)
                eff += e.Key + ", ";

            GUILayout.Label("====  " + a.actionName + "(" + pre + ")(" + eff + ")");
        }
        GUILayout.Label("Goals: ");
        foreach (KeyValuePair<SubGoal, int> g in agent.gameObject.GetComponent<GOAP_Agent>().goals)
        {
            GUILayout.Label("---: ");
            GUILayout.Label("=====  " + g.Key.sGoals.Key);
        }
        GUILayout.Label("Beliefs: ");
        foreach (KeyValuePair<string, int> sg in agent.gameObject.GetComponent<GOAP_Agent>().beliefs.GetStates)
        {
            GUILayout.Label("=====  " + sg.Key + "    " + sg.Value.ToString());
        }

        GUILayout.Label("Resources: ");
        foreach (GameObject g in agent.gameObject.GetComponent<GOAP_Agent>().inventory.items)
        {
            if(g != null)
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

        serializedObject.ApplyModifiedProperties();
    }
}
