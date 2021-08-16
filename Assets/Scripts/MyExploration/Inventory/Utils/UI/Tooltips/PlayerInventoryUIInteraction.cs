using MyExploration.UI.Inventories;
using UnityEngine;
using UnityEngine.EventSystems;
namespace MyExploration.Core.UI.PlayerInteraction
{
    public abstract class PlayerInventoryUIInteraction : MonoBehaviour, IPointerEnterHandler
    {

        // PRIVATE STATE
        ItemTooltip tooltip = null;
        ActionOptions actionOptions = null;

        void Start()
        {
            tooltip = FindObjectOfType<ItemTooltip>();
            actionOptions = FindObjectOfType<MyExploration.UI.Inventories.ActionOptions>();
        }

        public abstract void UpdateUI(ItemTooltip tooltip, ActionOptions actionOptions);
        public abstract void ResetUI(ItemTooltip tooltip, ActionOptions actionOptions);

        public abstract bool CanCreateUI();
        // PRIVATE

        private void OnDestroy()
        {
            ClearUI();
        }

        private void OnDisable()
        {
            ClearUI();
        }
        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (tooltip && actionOptions && !CanCreateUI())
            {
                ResetUI(tooltip, actionOptions);
            }
            if (tooltip && actionOptions && CanCreateUI())
            {
                UpdateUI(tooltip, actionOptions);
            }
        }

        private void ClearUI()
        {
            if (tooltip && actionOptions)
            {
                ResetUI(tooltip, actionOptions);
            }
        }
    }
}