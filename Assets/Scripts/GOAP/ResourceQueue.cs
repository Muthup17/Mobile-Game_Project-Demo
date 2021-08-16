using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceQueue
{
    public Queue<GameObject> rQueue = new Queue<GameObject>();
    public string tag;
    public string modState;

    public ResourceQueue(string t, string ms, States w)
    {
        tag = t;
        modState = ms;
        if (tag != "")
        {
            GameObject[] resources = GameObject.FindGameObjectsWithTag(tag);

            foreach (GameObject r in resources)
            {
                rQueue.Enqueue(r);
            }
        }
        if (modState != "")
        {
            w.ModifyState(modState, rQueue.Count);
        }
    }
    public void AddResource(GameObject r)
    {
        rQueue.Enqueue(r);
    }

    public GameObject RemoveResource()
    {
        if (rQueue.Count == 0) return null;
        return rQueue.Dequeue();
    }

    public void RemoveResource(GameObject r)
    {
        rQueue = new Queue<GameObject>(rQueue.Where(p => p != r));
    }
}
