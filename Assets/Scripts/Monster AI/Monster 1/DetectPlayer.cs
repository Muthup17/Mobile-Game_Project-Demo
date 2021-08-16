namespace AI.Monsters
{
    public class DetectPlayer : GOAP_Action
    {
        public override bool PostPerform()
        {
            beliefs.RemoveState("PlayerVisibled");
            beliefs.SetState("PlayerIsDetected", 1);
            this.gameObject.tag = "ChasingPlayer";
            return true;
        }

        public override bool PrePerform()
        {
            target = this.gameObject;
            gAgent.animationAgent.anim.SetTrigger("Rage");
            return true;
        }
    }
}
