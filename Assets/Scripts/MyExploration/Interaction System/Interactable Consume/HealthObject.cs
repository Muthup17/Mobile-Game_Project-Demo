using MyExploration.Inventories;
using System;
using UnityEngine;
using MyExploration.UI.Interactions;
public class HealthObject : PickableObject, IConsumable
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
    public static event Action<float> OnPlayerConsumeHealth;
    public bool Consume(InventoryItem item)
    {
        if(PlayerHealthSystem.Instance.PlayerCurrentHealth < PlayerHealthSystem.Instance.PlayerMaxHealth)
        {
            OnPlayerConsumeHealth?.Invoke(upgrade.CurrentPower);
            return true;
        }
        else
        {
            Debug.Log("Health is Already full");
            InteractionStateUI.Instance.StartShowandHide(InteractionStateUI.Instance.healthFull);
            return false;
        }

    }
    public bool Consume()
    {
        if (PlayerHealthSystem.Instance.PlayerCurrentHealth < PlayerHealthSystem.Instance.PlayerMaxHealth)
        {
            OnPlayerConsumeHealth?.Invoke(upgrade.CurrentPower);
            return true;
        }
        else
        {
            Debug.Log("Health is Already full");
            InteractionStateUI.Instance.StartShowandHide(InteractionStateUI.Instance.healthFull);
            return false;
        }

    }
}
