namespace AI.Monsters
{
    public class CheckKey : GOAP_Action
    {
        Chest m_chest;
        public override bool PostPerform()
        {
            beliefs.SetState("KeyIsAtPlace", 1);
            return true;
        }

        public override bool PrePerform()
        {
            if (m_chest == null)
            {
                m_chest = inventory.Chest.GetComponent<Chest>();
            }
            if (m_chest.IsContainsKey())
            {
                target = this.gameObject;
                return true;
            }
            else
            {
                beliefs.RemoveState("HavingKey");
                beliefs.SetState("KeyIsNotAtPlace", 1);
                return false;
            }

        }
    }
}

