using MyExploration.Inventories;
using System;
using UnityEngine;
using MyExploration.UI.Interactions;
public class SprintObject : PickableObject, IConsumable
{
    [SerializeField] ItemUpgrade upgrade;
    protected override void Start()
    {
        base.Start();
        if(upgrade == null)
        {
            Debug.LogError("Set Upgrade Properly");
        }
    }
    public static event Action<float> OnPlayerConsumeSprint;
    public bool Consume(InventoryItem item)
    {
        if(PlayerSprintSystem.Instance.CurrentEnergy < PlayerSprintSystem.Instance.MaxEnergy)
        {
            OnPlayerConsumeSprint?.Invoke(upgrade.CurrentPower);
            return true;
        }
        else
        {
            Debug.Log("Energy is Full");
            InteractionStateUI.Instance.StartShowandHide(InteractionStateUI.Instance.sprintFull);
            return false;
        }

    }
}
