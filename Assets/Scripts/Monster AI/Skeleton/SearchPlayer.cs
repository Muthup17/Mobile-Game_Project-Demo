using UnityEngine;

namespace AI.Skeletons
{
    public class SearchPlayer : GOAP_Action
    {
        public override bool PostPerform()
        {
            GOAP_World.Instance.GetResourceQueue("SearchPoint").AddResource(target);
            GOAP_World.Instance.World.ModifyState("FreeSearchPoint", 1);
            inventory.RemoveItem(target);
            return true;
        }

        public override bool PrePerform()
        {
            GameObject searchPoint = GOAP_World.Instance.GetResourceQueue("SearchPoint").RemoveResource();
            if (searchPoint != null)
            {
                target = searchPoint;
                GOAP_World.Instance.World.ModifyState("FreeSearchPoint", -1);
                inventory.AddItem(searchPoint);
                return true;
            }
            return false;
        }
    }
}
