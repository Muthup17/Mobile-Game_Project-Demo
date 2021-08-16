namespace AI.Skeletons
{
    public class DetectPlayer : GOAP_Action
    {
        public override bool PostPerform()
        {
            beliefs.RemoveState("Triggered");
            beliefs.SetState("PlayerIsDetected", 1);
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
