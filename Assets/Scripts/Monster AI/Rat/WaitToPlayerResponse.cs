using System;
using UnityEngine;

namespace AI.Rat
{
    public class WaitToPlayerResponse : GOAP_Action
    {
        public static event Action<GOAP_Agent> OnRatAskingGoal;
        public static event Action OnRatEndAskingGoal;
        public override bool PostPerform()
        {
            beliefs.RemoveState("AskGoalToPlayer");
            OnRatEndAskingGoal?.Invoke();
            beliefs.SetState("Return", 1);
            return true;
        }

        public override bool PrePerform()
        {
            target = this.gameObject;
            OnRatAskingGoal?.Invoke(gAgent);
            return true;
        }
    }
}
