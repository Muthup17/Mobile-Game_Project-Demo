using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GOAP_AgentVisualiser : MonoBehaviour
{
    public GOAP_Agent thisAgent;

    // Start is called before the first frame update
    void Start()
    {
        thisAgent = this.GetComponent<GOAP_Agent>();
    }
}
