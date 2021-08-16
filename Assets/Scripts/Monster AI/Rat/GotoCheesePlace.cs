using System.Collections;
using UnityEngine;

namespace AI.Rat
{
    public class GotoCheesePlace : GOAP_Action
    {
        public override bool PostPerform()
        {
            return true;
        }

        public override bool PrePerform()
        {
            target = inventory.FindItemWithTag("Cheese");
            if (target != null)
            {
                return true;
            }
            return false;
        }
    }
}
