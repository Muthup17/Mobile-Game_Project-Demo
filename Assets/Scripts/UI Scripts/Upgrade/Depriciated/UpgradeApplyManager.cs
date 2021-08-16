using System.Collections.Generic;
using UnityEngine;
using System;

public class UpgradeApplyManager : MonoBehaviour
{
    private static UpgradeApplyManager m_instance;
    public static UpgradeApplyManager Instance => m_instance;

    Queue<string> upgradedListQueue;

    public Queue<string> UpgradedQueue => upgradedListQueue;

    private void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        upgradedListQueue = new Queue<string>();
        Debug.Log("Called At Awake");
    }

    public void StartApplingUpgrade()
    {
        foreach(string component in upgradedListQueue)
        {
            if(component != "")
            {
                var com = FindObjectOfType(Type.GetType(component)) as MonoBehaviour;
                com.GetComponent<IInventoryUpgradeable>().UpdateUpgradeableField();
            }
        }
    }
}
