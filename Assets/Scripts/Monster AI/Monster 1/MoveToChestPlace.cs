namespace AI.Monsters
{
    public class MoveToChestPlace : GOAP_Action
    {
        public override bool PostPerform()
        {
            beliefs.SetState("AtChestPlace", 1);
            return true;
        }

        public override bool PrePerform()
        {
            target = inventory.Chest;
            if (target != null)
            {
                return true;
            }
            return false;
        }
    }
}
