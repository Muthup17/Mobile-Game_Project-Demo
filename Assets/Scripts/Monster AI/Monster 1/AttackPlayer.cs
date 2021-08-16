using UnityEngine;

namespace AI.Monsters
{
    public class AttackPlayer : GOAP_Action
    {
        GameObject player;
        public override bool PostPerform()
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance > gAgent.StopingDistance)
            {
                beliefs.RemoveState("ChasedPlayer");
                return false;
            }
            return true;
        }

        public override bool PrePerform()
        {
            player = inventory.FindItemWithTag("Player");
            target = this.gameObject;
            Vector3 dir = player.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(dir);
            int randomValue = Random.Range(0, 100);
            if (randomValue < 50)
            {
                gAgent.animationAgent.anim.SetTrigger("Attack 1");
            }
            else
            {
                gAgent.animationAgent.anim.SetTrigger("Attack 2");
            }
            return true;
        }
    }
}
