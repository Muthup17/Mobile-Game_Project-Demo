using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Rat
{
    public class EatCheese : GOAP_Action
    {
        public override bool PostPerform()
        {
            GameObject cheese = inventory.FindItemWithTag("Cheese");
            beliefs.SetState("AskGoalToPlayer", 1);
            inventory.RemoveItem(cheese);
            Destroy(cheese);
            return true;
        }

        public override bool PrePerform()
        {
            target = this.gameObject;
            return true;
        }
    }
}
