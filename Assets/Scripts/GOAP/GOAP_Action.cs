using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class GOAP_Action : MonoBehaviour
{
    public bool OR = false;
    public string actionName = "Action";
    public float cost = 1.0f;
    public GameObject target;
    public string targetTag;
    [HideInInspector]
    public Vector3 destination;
    public float duration = 0.0f;
    [SerializeField]
    private State[] setPreConditions;
    [SerializeField]
    private State[] setAfterEffects;
    [HideInInspector]
    public GOAP_Agent gAgent;
    [HideInInspector]
    public NavMeshAgent agent;
    public Dictionary<string, int> preConditions;
    public Dictionary<string, int> effects;
    public GOAP_Inventory inventory;
    public States beliefs;
    public bool running = false;
    public bool skipImmediate = false;

    public GOAP_Action()
    {
        preConditions = new Dictionary<string, int>();
        effects = new Dictionary<string, int>();
    }
    private void Awake()
    {
        beliefs = this.GetComponent<GOAP_Agent>().beliefs;
        inventory = this.GetComponent<GOAP_Agent>().inventory;
    }
    private void Start()
    {
        gAgent = this.GetComponent<GOAP_Agent>();
        agent = this.GetComponent<NavMeshAgent>();

        if (setPreConditions != null)
        {
            foreach (State w in setPreConditions)
            {
                preConditions.Add(w.key, w.value);
            }
        }
        if (setAfterEffects != null)
        {
            foreach (State w in setAfterEffects)
            {
                effects.Add(w.key, w.value);
            }
        }
    }
    public bool IsAchievable()
    {
        return true;
    }
    public bool IsAhievableGiven(Dictionary<string, int> conditions)
    {
        if (OR)
        {
            foreach (KeyValuePair<string, int> p in preConditions)
            {
                if (conditions.ContainsKey(p.Key))
                {
                    return true;
                }
                else
                {
                    continue;
                }
            }
            return false;
        }
        else
        {
            foreach (KeyValuePair<string, int> p in preConditions)
            {
                if (!conditions.ContainsKey(p.Key))
                {
                    return false;
                }
            }
            return true;
        }
    }
    public abstract bool PostPerform();
    public abstract bool PrePerform();
}
