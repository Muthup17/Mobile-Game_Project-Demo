using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Skeletons
{
    public class ArcherChase : GOAP_Action
    {
        [SerializeField] PlayerDetection pd;
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
                gameObject.tag = "Archer";
                return false;
            }
            return false;
        }

        public override bool PrePerform()
        {
            GameObject player = inventory.FindItemWithTag("Player");
            if(player != null)
            {
                float distance = Vector3.Distance(player.transform.position, transform.position);
                if (!gameObject.CompareTag("ChasingPlayer"))
                {
                    gameObject.tag = "ChasingPlayer";
                }
                if (distance > gAgent.StopingDistance && distance < gAgent.escapeDistance && pd.playerVisibled)
                {
                    beliefs.SetState("ReadyToShoot", 1);
                    GameObject searchPoint = inventory.FindItemWithTag("SearchPoint");
                    if (searchPoint)
                    {
                        GOAP_World.Instance.GetResourceQueue("SearchPoint").AddResource(searchPoint);
                        GOAP_World.Instance.World.ModifyState("FreeSearchPoint", 1);
                        inventory.RemoveItem(searchPoint);
                    }
                    return false;
                }
                else if(distance < gAgent.StopingDistance)
                {
                    beliefs.SetState("ChasedPlayer", 1);
                    return false;
                }
                else
                {
                    target = player;
                    gAgent.animationAgent.anim.SetBool("Run", true);
                    return true;
                }
            }
            return false;
        }
    }
}
