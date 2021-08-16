using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipTrigger : MonoBehaviour
{
    [SerializeField] int index;
    private void OnTriggerEnter(Collider other)
    {
        if(PlayerDemoLearningSystem.Instance.nextTipIndex == index)
        {
            if (other.CompareTag("Player"))
            {
                if (!PlayerDemoLearningSystem.Instance.Learn.learnItems[index].value)
                {
                    PlayerDemoLearningSystem.Instance.tipRequested = true;
                    PlayerDemoLearningSystem.Instance.currentTipIndex = index;
                }
            }
        }

    }
}
