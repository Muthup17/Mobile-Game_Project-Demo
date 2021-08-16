using UnityEngine;

namespace AI.Skeletons
{
    public class ChasePlayer : GOAP_Action
    {
        public override bool PostPerform()
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if (distance < gAgent.StopingDistance)
            {
                gAgent.animationAgent.anim.SetBool("Run", false);
                beliefs.SetState("ChasedPlayer", 1);
                return true;
            }
            else if (distance > gAgent.escapeDistance)
            {
                gAgent.animationAgent.anim.SetBool("Run", false);
                beliefs.RemoveState("PlayerIsDetected");
                inventory.RemoveItem(target.gameObject);
                beliefs.SetState("GotoSearchForPlayer", 1);
                this.gameObject.tag = "Skeleton";
                return false;
            }
            return false;
        }

        public override bool PrePerform()
        {
            target = inventory.FindItemWithTag("Player");
            if (target != null)
            {
                if (!gameObject.CompareTag("ChasingPlayer"))
                {
                    gameObject.tag = "ChasingPlayer";
                }
                gAgent.animationAgent.anim.SetBool("Run", true);
                return true;
            }
            return false;
        }
    }
}

