using UnityEngine;
using TMPro;
using MyExploration.Inventories;
using UnityEngine.UI;
namespace MyExploration.UI.Inventories
{
    /// <summary>
    /// Root of the tooltip prefab to expose properties to other classes.
    /// </summary>
    ///
    [DefaultExecutionOrder(100)]
    public class ItemTooltip : MonoBehaviour
    {
        // CONFIG DATA
        [SerializeField] Text titleText = null;
        [SerializeField] Text bodyText = null;

        // PUBLIC

        private void OnEnable()
        {
            var item = Inventory.GetPlayerInventory().GetItemInSlot(0);
            if (item)
            {
                Setup(item);
            }
        }

        public void Setup(InventoryItem item)
        {
            titleText.text = item.GetDisplayName();
            bodyText.text = item.GetDescription();
        }

        public void ResetText()
        {
            titleText.text = "";
            bodyText.text = "";
        }
    }
}
