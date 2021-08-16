namespace AI.Monsters
{
    public class ShootAttack : GOAP_Action
    {
        public override bool PostPerform()
        {
            beliefs.RemoveState("ReadyToShoot");
            return true;
        }

        public override bool PrePerform()
        {
            target = this.gameObject;
            gAgent.animationAgent.anim.SetTrigger("Shoot");
            return true;
        }
    }
}
