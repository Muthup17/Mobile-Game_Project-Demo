using System.Collections.Generic;
public class GOAP_Planner
{
    public Queue<GOAP_Action> plan(List<GOAP_Action> actions, KeyValuePair<string, int> goal, States beliefStates)
    {
        List<GOAP_Action> usableActions = new List<GOAP_Action>();
        foreach (GOAP_Action a in actions)
        {
            if (a.IsAchievable())
            {
                usableActions.Add(a);
            }
        }
        // Only goal ended nodes are stored here
        List<Node> leaves = new List<Node>();
        Node start = new Node(null, 0.0f, GOAP_World.Instance.World.GetStates, beliefStates.GetStates, null);

        bool success = BuildGraph(start, leaves, usableActions, goal);

        if (!success)
        {
            return null;
        }

        // Cheapest Node will be selected for executing the plan
        Node cheapest = null;
        foreach (Node leaf in leaves)
        {

            if (cheapest == null)
            {

                cheapest = leaf;
            }
            else if (leaf.cost < cheapest.cost)
            {

                cheapest = leaf;
            }
        }
        List<GOAP_Action> result = new List<GOAP_Action>();
        Node n = cheapest;

        // Back Propagation is happening here. From Cheapest GoalNode to StartNode
        // StartNode doesn't contain root or parent node.
        while (n != null)
        {

            if (n.action != null)
            {
                // Inserting At 0th index means we are doing ascending order. This way GoalNode will be at the end of the List
                result.Insert(0, n.action);
            }

            n = n.parent;
        }

        Queue<GOAP_Action> queue = new Queue<GOAP_Action>();

        foreach (GOAP_Action a in result)
        {
            queue.Enqueue(a);
        }
        foreach (GOAP_Action a in queue)
        {

            // Debug.Log("Q: " + a.actionName);
        }

        return queue;
    }

    private bool BuildGraph(Node parent, List<Node> leaves, List<GOAP_Action> usableActions, KeyValuePair<string, int> goal)
    {

        bool foundPath = false;
        foreach (GOAP_Action action in usableActions)
        {
            // Current iterating Action does contain the precondition that match with world and agent states
            if (action.IsAhievableGiven(parent.state))
            {
                // this contains all the states of the game. Including agent states.
                Dictionary<string, int> currentState = new Dictionary<string, int>(parent.state);
                foreach (KeyValuePair<string, int> eff in action.effects)
                {
                    if (!currentState.ContainsKey(eff.Key))
                    {
                        currentState.Add(eff.Key, eff.Value);
                    }
                }
                Node node = new Node(parent, parent.cost + action.cost, currentState, action);

                // current action's effect does match with the goal
                if (GoalAchieved(goal, currentState))
                {
                    leaves.Add(node);
                    foundPath = true;
                }
                else
                {
                    // this contains all actions except current iterating action
                    List<GOAP_Action> subset = ActionSubset(usableActions, action);
                    // Multipe Recursive call will be performed in order to make a graph
                    bool found = BuildGraph(node, leaves, subset, goal);
                    if (found)
                    {
                        foundPath = true;
                    }
                }
            }
        }
        return foundPath;
    }

    private List<GOAP_Action> ActionSubset(List<GOAP_Action> actions, GOAP_Action removeMe)
    {
        List<GOAP_Action> subset = new List<GOAP_Action>();
        foreach (GOAP_Action a in actions)
        {
            if (!a.Equals(removeMe))
            {
                subset.Add(a);
            }
        }
        return subset;
    }
    private bool GoalAchieved(KeyValuePair<string, int> goal, Dictionary<string, int> state)
    {
        if (!state.ContainsKey(goal.Key))
        {
            return false;
        }
        return true;
    }
}
