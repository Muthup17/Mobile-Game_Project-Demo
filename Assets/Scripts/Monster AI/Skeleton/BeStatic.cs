namespace AI.Skeletons
{
    public class BeStatic : GOAP_Action
    {
        public override bool PostPerform()
        {
            return true;
        }

        public override bool PrePerform()
        {
            target = this.gameObject;
            return true;
        }
    }
}
