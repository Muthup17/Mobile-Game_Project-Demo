using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using MyExploration.Inventories;
using MyExploration.Core.UI.Dragging;
using UnityEngine.UI;
namespace MyExploration.UI.Inventories
{
    [DefaultExecutionOrder(100)]
    public class ActionOptions : MonoBehaviour
    {
        // CONFIG DATA
        [SerializeField] Text consume = null;
        [SerializeField] Text equip = null;
        [SerializeField] Text remove = null;

        InventorySlotUI slotUI;
        [SerializeField] GameObject inventoryItems;
        Canvas parentCanvas;

        private void Start()
        {
            parentCanvas = this.GetComponentInParent<Canvas>();;
        }

        private void OnEnable()
        {
            var item = Inventory.GetPlayerInventory().GetItemInSlot(0);
            if (item)
            {
                Setup(item);
                slotUI = inventoryItems.transform.GetChild(0).GetComponent<InventorySlotUI>();
                slotUI.transform.GetChild(0).gameObject.SetActive(true);
            }
        }

        // PUBLIC

        public void Setup(InventoryItem item)
        {
            if (!item.IsConsumable())
            {
                consume.transform.parent.gameObject.SetActive(false);
            }
            else
            {
                consume.transform.parent.gameObject.SetActive(true);
                /*consume.text = "CONSUME";*/
            }
            if(slotUI != null)
            {
                slotUI.transform.GetChild(0).gameObject.SetActive(true);
            }
            /*equip.text = "EQUIP";
            remove.text = "DROP";*/
        }

        public void InitVar(InventorySlotUI slot)
        {
            slotUI = slot;
        }
        public void RemoveItem()
        {
            if (slotUI)
            {
                IDragSource<InventoryItem> source = slotUI.GetComponent<IDragSource<InventoryItem>>();
                IDragDestination<InventoryItem> destination = parentCanvas.GetComponent<IDragDestination<InventoryItem>>();
                destination.AddItems(slotUI.GetItem(), slotUI.GetNumber());
                source.RemoveItems(slotUI.GetNumber());
            }
        }

        public void EquipItem()
        {
            if (slotUI)
            {
                IDragSource<InventoryItem> source = slotUI.GetComponent<IDragSource<InventoryItem>>();
                var destination = parentCanvas.GetComponent<InventoryDropTarget>();
                InventoryItem item = slotUI.GetItem();
                int quantity = slotUI.GetNumber();
                if (PlayerInteractionData.Instance.AmIHoldSomething())
                {
                    source.RemoveItems(quantity);
                    PlayerInteractionData.Instance.CurrentHoldingObject.gameObject.GetComponent<Pickup>().PickupItem();
                    destination.EquipItem(item, quantity);
                }
                else
                {
                    destination.EquipItem(item, quantity);
                    source.RemoveItems(quantity);
                }

            }
        }

        public void ConsumeItem()
        {
            if (slotUI)
            {
                InventoryItem item = slotUI.GetItem();
                bool success = item.GetPickUp().ConsumeIt();
                if (success)
                {
                    IDragSource<InventoryItem> source = slotUI.GetComponent<IDragSource<InventoryItem>>();
                    source.RemoveItems(1);
                }
                else
                {
                    Debug.Log("Failed");
                }

            }
        }

        public void ResetSlotUI()
        {
            if(slotUI != null)
            {
                slotUI.transform.GetChild(0).gameObject.SetActive(false);
            }
            slotUI = null;
        }
    }
}
