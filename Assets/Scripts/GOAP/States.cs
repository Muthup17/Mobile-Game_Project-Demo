using System.Collections.Generic;

[System.Serializable]
public class State
{
    public string key;
    public int value;
}

public class States
{
    private Dictionary<string, int> states;
    public States()
    {
        states = new Dictionary<string, int>();
    }

    public Dictionary<string, int> GetStates { get { return states; } }
    public bool HasState(string key)
    {
        return states.ContainsKey(key);
    }

    private void AddState(string key, int value)
    {

        states.Add(key, value);
    }

    public void ModifyState(string key, int value)
    {
        if (HasState(key))
        {
            states[key] += value;
            if (states[key] <= 0)
            {
                RemoveState(key);
            }
        }
        else
        {
            AddState(key, value);
        }
    }

    public void RemoveState(string key)
    {
        if (HasState(key))
        {

            states.Remove(key);
        }
    }

    public void SetState(string key, int value)
    {
        if (HasState(key))
        {
            states[key] = value;
        }
        else
        {
            AddState(key, value);
        }
    }
}
