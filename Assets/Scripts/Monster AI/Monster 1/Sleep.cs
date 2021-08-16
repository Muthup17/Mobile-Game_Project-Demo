namespace AI.Monsters
{
    public class Sleep : GOAP_Action
    {
        public override bool PostPerform()
        {
            if (gAgent.animationAgent.anim.GetBool("Run"))
            {
                gAgent.animationAgent.anim.SetBool("Run", false);
            }
            gAgent.animationAgent.anim.SetTrigger("StandUp");
            this.GetComponent<MonsterHealthSystem>().CurrentPoisonAffect = 100;
            return true;
        }

        public override bool PrePerform()
        {
            target = this.gameObject;
            return true;
        }
    }
}
