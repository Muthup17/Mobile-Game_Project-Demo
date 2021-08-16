using UnityEngine;
using MyExploration.Interaction;

namespace MyExploration.Inventories
{
    /// <summary>
    /// To be placed at the root of a Pickup prefab. Contains the data about the
    /// pickup such as the type of item and the number.
    /// </summary>
    public class Pickup : MonoBehaviour
    {
        // STATE
        [SerializeField] InventoryItem item;
        [SerializeField] int quantity = 1;

        // CACHED REFERENCE
        Inventory inventory;

        // LIFECYCLE METHODS
        Rigidbody rb;
        InteractableObject interactableObject;
        private void Awake()
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            inventory = player.GetComponent<Inventory>();
            rb = GetComponent<Rigidbody>();
            interactableObject = this.GetComponent<InteractableObject>();
        }

        private void Update()
        {

        }

        // PUBLIC

        /// <summary>
        /// Set the vital data after creating the prefab.
        /// </summary>
        /// <param name="item">The type of item this prefab represents.</param>
        /// <param name="quantity">The number of items represented.</param>
        public void Setup(InventoryItem item, int quantity)
        {
            this.item = item;
            if (!item.IsStackable())
            {
                quantity = 1;
            }
            this.quantity = quantity;
        }

        public InventoryItem GetItem()
        {
            return item;
        }

        public int GetQuantity()
        {
            return quantity;
        }
        public void SetQuantity( int value)
        {
            quantity = value;
        }

        public void PickupItem()
        {
            bool foundSlot = inventory.AddToFirstEmptySlot(item, quantity);
            if (foundSlot)
            {
                PlayerInteractionData.Instance.PlayerState = PlayerStates.HOLDNOTHING;
                Destroy(gameObject);
            }
        }

        public bool CanBePickedUp()
        {
            return inventory.HasSpaceFor(item);
        }

        public void ReduceQuantity()
        {
            quantity--;
        }

        public void HoldIt()
        {
            transform.SetParent(PlayerInteractionData.Instance.HoldingAnchor);
            GetComponentInChildren<Collider>().gameObject.layer = LayerMask.NameToLayer("Interacting");
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
            rb.isKinematic = true;
            ResetTransform();
            PlayerInteractionData.Instance.CurrentHoldingObject = this.GetComponent<InteractableObject>();
            PlayerInteractionData.Instance.IsConsumable = item.IsConsumable();
        }
        public bool ConsumeIt()
        {
            if (item)
            {
                bool success = this.GetComponent<IConsumable>().Consume(item);
                return success;
            }
            else
            {
                Debug.Log("Set inventory Item Properly");
                return false;
            }

        }

        void ResetTransform()
        {
            transform.localPosition = Vector3.zero;
            transform.localEulerAngles = Vector3.zero;
            transform.localScale = Vector3.one;
        }
    }
}