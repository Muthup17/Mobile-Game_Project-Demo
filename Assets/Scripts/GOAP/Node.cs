using System.Collections.Generic;
public class Node
{
    public Node parent;
    public float cost;
    public Dictionary<string, int> state;
    public GOAP_Action action;

    public Node(Node parent, float cost, Dictionary<string, int> allStates, GOAP_Action action)
    {
        this.parent = parent;
        this.cost = cost;
        this.state = new Dictionary<string, int>(allStates);
        this.action = action;
    }

    public Node(Node parent, float cost, Dictionary<string, int> allStates, Dictionary<string, int> beliefStates, GOAP_Action action)
    {
        this.parent = parent;
        this.cost = cost;
        this.state = new Dictionary<string, int>(allStates);

        foreach (KeyValuePair<string, int> b in beliefStates)
        {
            if (!this.state.ContainsKey(b.Key))
            {
                this.state.Add(b.Key, b.Value);
            }
        }
        this.action = action;
    }
}