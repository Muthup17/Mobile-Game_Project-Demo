using System.Collections;
using MyExploration.UI.Interactions;
using UnityEngine;
using MyExploration.Inventories;
public class KeyObject : PickableObject, IConsumable
{
    public bool Consume(InventoryItem item)
    {
        var obj = PlayerInteractionData.Instance.CurrentInteractableObject;
        if(obj != null)
        {
            IValidatable door = obj.GetComponent<IValidatable>();
            if (item.GetItemID().Equals(door.ID))
            {
                door.StateOfInteraction = InteractionState.UNLOCKED;
                Debug.Log("UnLocked");
                InteractionStateUI.Instance.StartShowandHide(InteractionStateUI.Instance.unLocked);
                return true;
            }
            else
            {
                InteractionStateUI.Instance.StartShowandHide(InteractionStateUI.Instance.wrongKey);
                return false;
            }
        }
        else
        {
            Debug.Log("Place the curson on the object");
            return false;
        }

    }
    public override void HoldTheObject()
    {
        base.HoldTheObject();
        if (!UserLearningSystem.Instance.Learn.learnItems[1].value)
        {
            UserLearningSystem.Instance.tipRequested = true;
            UserLearningSystem.Instance.currentTipIndex = 1;
        }
    }
}
