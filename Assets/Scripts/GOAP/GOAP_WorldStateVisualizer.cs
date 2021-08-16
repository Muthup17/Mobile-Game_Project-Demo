using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GOAP_WorldStateVisualizer : MonoBehaviour
{

    public GOAP_World gWorld;
    void Awake()
    {
        gWorld = GOAP_World.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
