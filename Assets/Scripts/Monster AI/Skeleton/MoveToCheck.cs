using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Skeletons
{
    public class MoveToCheck : GOAP_Action
    {
        public override bool PostPerform()
        {
            return true;
        }

        public override bool PrePerform()
        {
            target = inventory.FindRecentlyAddedItem();
            if (target != null)
            {
                duration = Random.Range(5, 10);
                Debug.Log("Proceeded");
                beliefs.RemoveState("SoundHeard");
                inventory.RemoveItem(target);
                return true;
            }
            Debug.Log("Cancelled");
            return false;
        }
    }
}
