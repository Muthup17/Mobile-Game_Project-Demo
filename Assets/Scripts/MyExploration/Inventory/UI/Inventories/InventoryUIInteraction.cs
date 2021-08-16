using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyExploration.Core.UI.PlayerInteraction;

namespace MyExploration.UI.Inventories
{
    /// <summary>
    /// To be placed on a UI slot to spawn and show the correct item tooltip.
    /// </summary>
    [RequireComponent(typeof(IItemHolder))]
    public class InventoryUIInteraction : PlayerInventoryUIInteraction
    {
        public override bool CanCreateUI()
        {
            var item = GetComponent<IItemHolder>().GetItem();
            if (!item) return false;

            return true;
        }

        public override void UpdateUI(ItemTooltip tooltip, ActionOptions actionOptions)
        {
            if (!tooltip) return;
            if (!actionOptions) return;
            actionOptions.ResetSlotUI();
            InventorySlotUI slotUI = GetComponent<InventorySlotUI>();
            var item = slotUI.GetItem();
            tooltip.Setup(item);
            actionOptions.InitVar(slotUI);
            actionOptions.Setup(item);
        }

        public override void ResetUI(ItemTooltip tooltip, ActionOptions actionOptions)
        {
            if (!tooltip) return;
            if (!actionOptions) return;
            tooltip.ResetText();
            actionOptions.ResetSlotUI();
        }

    }
}