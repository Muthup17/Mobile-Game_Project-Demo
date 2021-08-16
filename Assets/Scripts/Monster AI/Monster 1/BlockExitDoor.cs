using UnityEngine;

namespace AI.Monsters
{
    public class BlockExitDoor : GOAP_Action
    {
        float startTime, elapsedTime;
        [SerializeField] float maxTime;
        public override bool PostPerform()
        {
            elapsedTime = Time.time - startTime;
            if (elapsedTime >= maxTime)
            {
                beliefs.SetState("GotoSearchForPlayer", 1);
                elapsedTime = 0;
                return true;
            }
            return true;
        }

        public override bool PrePerform()
        {
            target = this.gameObject;
            if (gAgent.isGoalChanged)
            {
                startTime = Time.time;
            }
            return true;

        }
    }
}
