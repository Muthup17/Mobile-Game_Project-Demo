using UnityEngine;

namespace AI.Skeletons
{
    public class AttackPlayer : GOAP_Action
    {
        GameObject player;
        [SerializeField]Skeleton skeleton;
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
            SetActions();
            return true;
        }
        void SetActions()
        {
            int randomValue = Random.Range(0, 100);
            switch (skeleton.role)
            {
                case SkeletonType.ARCHER:
                    gAgent.animationAgent.anim.SetTrigger("Attack 1");
                    break;
                case SkeletonType.SINGLEHANDSWORDSWEEPER:
                    if (randomValue < 50)
                    {
                        gAgent.animationAgent.anim.SetTrigger("Attack 1");
                    }
                    else if (randomValue > 50 && randomValue < 75)
                    {
                        gAgent.animationAgent.anim.SetTrigger("Attack 2");
                    }
                    else
                    {
                        gAgent.animationAgent.anim.SetTrigger("Attack 3");
                    }
                    break;
                case SkeletonType.TWOHANDSWORDSWEEPER:
                    if (randomValue < 50)
                    {
                        gAgent.animationAgent.anim.SetTrigger("Attack 1");
                    }
                    else
                    {
                        gAgent.animationAgent.anim.SetTrigger("Attack 2");
                    }
                    break;
            }
        }
    }
}
