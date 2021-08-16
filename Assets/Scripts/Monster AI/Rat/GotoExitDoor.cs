namespace AI.Rat
{
    public class GotoExitDoor : GOAP_Action
    {
        public override bool PostPerform()
        {
            beliefs.RemoveState("GoToExitDoor");
            beliefs.RemoveState("HasGoal");
            beliefs.SetState("Return", 1);
            return true;
        }

        public override bool PrePerform()
        {
            target = inventory.FindItemWithTag("ExitDoor");
            if(target != null)
            {
                return true;
            }
            return false;
        }
    }
}
