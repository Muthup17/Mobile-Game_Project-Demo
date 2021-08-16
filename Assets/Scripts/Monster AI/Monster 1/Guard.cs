namespace AI.Monsters
{
    public class Guard : GOAP_Action
    {
        public override bool PostPerform()
        {
            transform.rotation = target.transform.rotation;
            return true;
        }

        public override bool PrePerform()
        {
            target = inventory.Chest.transform.Find("Guard").gameObject;
            if (target != null)
            {
                return true;
            }
            return false;
        }
    }
}
