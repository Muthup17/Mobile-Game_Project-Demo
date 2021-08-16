using UnityEngine;

namespace AI.Monsters
{
    public class MoveToExitDoor : GOAP_Action
    {
        public override bool PostPerform()
        {
            beliefs.SetState("AtExitDoorArea", 1);
            gAgent.animationAgent.anim.SetBool("Run", false);
            return true;
        }

        public override bool PrePerform()
        {
            if (GOAP_World.Instance.World.HasState("FreeExitDoor"))
            {
                GameObject mainExitDoor = GOAP_World.Instance.GetResourceQueue("ExitDoor").RemoveResource();
                GOAP_World.Instance.World.ModifyState("FreeExitDoor", -1);
                target = mainExitDoor;
                inventory.AddItem(target);
                gAgent.animationAgent.anim.SetBool("Run", true);
                return true;
            }
            else
            {
                GameObject exitDoorCover = GOAP_World.Instance.GetResourceQueue("ExitDoorCover").RemoveResource();
                if (exitDoorCover != null)
                {
                    target = exitDoorCover;
                    inventory.AddItem(target);
                    GOAP_World.Instance.World.ModifyState("FreeExitDoorCover", -1);
                    gAgent.animationAgent.anim.SetBool("Run", true);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
