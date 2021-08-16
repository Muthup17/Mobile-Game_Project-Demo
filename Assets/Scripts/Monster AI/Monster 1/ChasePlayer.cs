using UnityEngine;

namespace AI.Monsters
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
                this.gameObject.tag = "Monster";
                return false;
            }
            return false;
        }

        public override bool PrePerform()
        {
            target = inventory.FindItemWithTag("Player");
            if (target != null)
            {
                gAgent.animationAgent.anim.SetBool("Run", true);
                return true;
            }
            return false;
        }
    }
}

