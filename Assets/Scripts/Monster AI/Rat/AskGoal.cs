using System.Collections;
using UnityEngine;
namespace AI.Rat
{
    public class AskGoal : GOAP_Action
    {
        public override bool PostPerform()
        {
            return true;
        }

        public override bool PrePerform()
        {
            Debug.Log(inventory);
            Debug.Log(inventory.FindItemWithTag("Player"));
            GameObject targetObj = inventory.FindItemWithTag("Player");
            if (targetObj != null)
            {
                Vector3 targetDir = (targetObj.transform.position - transform.position).normalized;
                target = this.gameObject;
                gAgent.isPause = true;
                StartCoroutine(TurnToTargetDirection(targetDir));
                return true;
            }
            return false;
        }
        IEnumerator TurnToTargetDirection(Vector3 dir)
        {
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            while (true)
            {
                Debug.Log("repeating");
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * 250f);
                float dotValue = Vector3.Dot(transform.forward, dir);
                if (dotValue > 0.9f)
                {
                    Debug.Log("RatFinished");
                    gAgent.isPause = false;
                    break;
                }
                yield return null;
            }
        }
    }
}
