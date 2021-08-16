using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class SubGoal
{
    public KeyValuePair<string, int> sGoals;
    public bool remove;
    public SubGoal(string s, int i, bool r)
    {
        sGoals = new KeyValuePair<string, int>(s, i);
        remove = r;
    }
}

public class GOAP_Agent : MonoBehaviour
{
    [HideInInspector]
    public List<GOAP_Action> actions = new List<GOAP_Action>();
    public Dictionary<SubGoal, int> goals = new Dictionary<SubGoal, int>();
    public GOAP_Inventory inventory = new GOAP_Inventory();
    public States beliefs = new States();
    GOAP_Planner planner;
    public Queue<GOAP_Action> actionQueue;
    [HideInInspector]
    public GOAP_Action currentAction;
    public SubGoal currentGoal;
    public SubGoal previousGoal;
    public bool isGoalChanged;
    Vector3 destination = Vector3.zero;
    [HideInInspector]
    public int currentWayPointIndex = 0;
    public bool isPause = false;
    public LocomotionSimpleAgent animationAgent;
    public float StopingDistance = 2;
    public float escapeDistance;
    public void Start()
    {
        GOAP_Action[] acts = this.GetComponents<GOAP_Action>();
        foreach (GOAP_Action a in acts)
            actions.Add(a);
    }

    bool invoked = false;
    void CompleteAction()
    {
        currentAction.running = false;
        if (!currentAction.PostPerform())
        {
            actionQueue = null;
        }
        invoked = false;
        if (currentAction.skipImmediate)
        {
            currentAction.skipImmediate = false;
        }
    }


    void SkipAction()
    {
        currentAction.running = false;
        invoked = false;
        actionQueue = null;
        currentAction.skipImmediate = false;
    }
    private void LateUpdate()
    {
        if (currentAction != null && isPause)
        {
            return;
        }
        else if (currentAction != null && currentAction.skipImmediate)
        {
            currentAction.agent.ResetPath();
            previousGoal = currentGoal;
            SkipAction();
            CancelInvoke();
        }
        else if (currentAction != null && currentAction.running)
        {
            // Special Case for Chase
            if (currentAction.GetType().Equals(typeof(AI.Monsters.ChasePlayer)) || currentAction.GetType().Equals(typeof(AI.Skeletons.ChasePlayer)) || currentAction.GetType().Equals(typeof(AI.Skeletons.ArcherChase)))
            {
                GameObject player = inventory.FindItemWithTag("Player");
                float x = player.transform.position.x;
                float y = this.gameObject.transform.position.y;
                float z = player.transform.position.z;
                destination = new Vector3(x, y, z);
                currentAction.agent.SetDestination(destination);
            }
            float distanceToTarget = Vector3.Distance(transform.position, destination);
            if (distanceToTarget < StopingDistance)       //currentAction.agent.remainingDistance < 0.5f)
            {
                // Debug.Log("Distance to Goal: " + currentAction.agent.remainingDistance);
                if (!invoked)
                {
                    Invoke("CompleteAction", currentAction.duration);
                    invoked = true;
                }
            }
            // Special case for Chase
            else if(distanceToTarget > escapeDistance && currentAction.GetType().Equals(typeof(AI.Monsters.ChasePlayer)) || distanceToTarget > escapeDistance && currentAction.GetType().Equals(typeof(AI.Skeletons.ChasePlayer)) || distanceToTarget > escapeDistance && currentAction.GetType().Equals(typeof(AI.Skeletons.ArcherChase)))
            {
                CompleteAction();
            }
            return;
        }

        if (planner == null || actionQueue == null)
        {
            planner = new GOAP_Planner();
            var sortedGoals = from entry in goals orderby entry.Value descending select entry;
            foreach (KeyValuePair<SubGoal, int> sg in sortedGoals)
            {
                actionQueue = planner.plan(actions, sg.Key.sGoals, beliefs);
                if (actionQueue != null)
                {
                    currentGoal = sg.Key;
                    isGoalChanged = !currentGoal.Equals(previousGoal) ? true : false;
/*                    Debug.Log(isGoalChanged);*/
                    break;
                }
            }
        }

        if (actionQueue != null && actionQueue.Count == 0)
        {
            if (currentGoal.remove)
            {
                goals.Remove(currentGoal);
            }
            previousGoal = currentGoal;
            planner = null;
        }

        if (actionQueue != null && actionQueue.Count > 0)
        {
            currentAction = actionQueue.Dequeue();
            if (currentAction.PrePerform())
            {
                if (currentAction.target == null && currentAction.targetTag != "")
                {
                    currentAction.target = GameObject.FindWithTag(currentAction.targetTag);
                }

                if (currentAction.target != null)
                {
                    currentAction.running = true;
                    float x = currentAction.target.transform.position.x;
                    float y = this.gameObject.transform.position.y;
                    float z = currentAction.target.transform.position.z;
                    destination = new Vector3(x, y, z);
                    currentAction.agent.SetDestination(destination);
                }
            }
            else
            {
                actionQueue = null;
                previousGoal = currentGoal;
            }
        }
    }
}
