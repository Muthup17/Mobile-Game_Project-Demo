using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyExploration.Core.UI.Dragging;
using MyExploration.Inventories;
using MyExploration.Interaction;

namespace MyExploration.UI.Inventories
{
    /// <summary>
    /// Handles spawning pickups when item dropped into the world.
    /// 
    /// Must be placed on the root canvas where items can be dragged. Will be
    /// called if dropped over empty space. 
    /// </summary>
    public class InventoryDropTarget : MonoBehaviour, IDragDestination<InventoryItem>
    {
        GameObject player;
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        public void AddItems(InventoryItem item, int number)
        {
            player.GetComponent<ItemDropper>().DropItem(item, number);
        }

        public void EquipItem(InventoryItem item, int number)
        {
            player.GetComponent<ItemDropper>().DropItemAtHand(item, number);
            PlayerInteractionData.Instance.PlayerState = PlayerStates.HOLDING;
        }

        public int MaxAcceptable(InventoryItem item)
        {
            return int.MaxValue;
        }
    }
}