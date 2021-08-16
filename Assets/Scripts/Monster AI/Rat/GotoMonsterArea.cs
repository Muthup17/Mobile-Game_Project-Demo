using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AI.Rat
{
    public class GotoMonsterArea : GOAP_Action
    {
        public override bool PostPerform()
        {
            beliefs.RemoveState("GoToMonsterArea");
            beliefs.RemoveState("HasGoal");
            beliefs.SetState("Return", 1);
            return true;
        }

        public override bool PrePerform()
        {
            target = inventory.FindItemWithTag("MonsterArea");
            if(target != null)
            {
                return true;
            }
            return false;
        }
    }
}
