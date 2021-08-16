using System.Collections;
using UnityEngine;

namespace AI.Monsters
{
    public class TurnToSoundDirection : GOAP_Action
    {
        [SerializeField] float turnAnimationLength;
        GameObject targetObj;
        public override bool PostPerform()
        {
            beliefs.RemoveState("FootStepSoundHeard");
            inventory.RemoveItem(targetObj);
            return true;
        }

        public override bool PrePerform()
        {
            targetObj = inventory.FindRecentlyAddedItem();
            if(targetObj != null)
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
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * 250f);
                float dotValue = Vector3.Dot(transform.forward, dir);
                if(dotValue > 0.9f)
                {
                    Debug.Log("Finished");
                    gAgent.isPause = false;
                    break;
                }
                yield return null;
            }
        }
        float TurnDirection()
        {
            Vector3 targetDir = (targetObj.transform.position - transform.position).normalized;
            float value = Vector3.Dot(transform.right, targetDir);
            return value;
        }
    }
}
