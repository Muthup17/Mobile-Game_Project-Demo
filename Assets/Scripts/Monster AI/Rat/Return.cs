using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Rat
{
    public class Return : GOAP_Action
    {
        public override bool PostPerform()
        {
            beliefs.RemoveState("Return");
            Destroy(this.gameObject);
            return true;
        }

        public override bool PrePerform()
        {
            target = this.gameObject;
            return true;
        }
    }
}
