using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOAP_StateMonitor : MonoBehaviour
{
    public string state;
    public float stateStrength;
    public float stateDecayRate;
    public States beliefs;
    public GameObject resourcePrefab;
    public string queueName;
    public string worldState;
    public GOAP_Action action;
    private bool stateFound = false;
    private float initialStrength;
    void Awake()
    {
        beliefs = this.GetComponent<GOAP_Agent>().beliefs;
        initialStrength = stateStrength;
    }


    void LateUpdate()
    {

        if (action.running)
        {
            stateFound = false;
            stateStrength = initialStrength;
        }

        if (!stateFound && beliefs.HasState(state))
        {
            stateFound = true;
        }

        if (stateFound)
        {
            stateStrength -= stateDecayRate * Time.deltaTime;
            if (stateStrength <= 0.0f)
            {
                Vector3 location = new Vector3(this.transform.position.x, resourcePrefab.transform.position.y, this.transform.position.z);
                GameObject p = Instantiate(resourcePrefab, location, resourcePrefab.transform.rotation);
                stateFound = false;
                stateStrength = initialStrength;
                beliefs.RemoveState(state);
                GOAP_World.Instance.GetResourceQueue(queueName).AddResource(p);
                GOAP_World.Instance.World.ModifyState(worldState, 1);
            }
        }
    }
}
