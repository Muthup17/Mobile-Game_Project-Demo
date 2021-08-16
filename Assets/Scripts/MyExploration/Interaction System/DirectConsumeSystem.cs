using UnityEngine;
using MyExploration.Inventories;

namespace MyExploration.Interaction
{
    public class DirectConsumeSystem : MonoBehaviour
    {
        private void Update()
        {
            if (PlayerInteractionData.Instance.PlayerState.Equals(PlayerStates.HOLDING))
            {
                if (PlayerMovement_InputData.Instance.ConsumePressed)
                {
                    Pickup pickup = PlayerInteractionData.Instance.CurrentHoldingObject.GetComponent<Pickup>();
                    if(pickup != null)
                    {
                        InventoryItem item = pickup.GetItem();
                        if (item.IsConsumable())
                        {
                            bool success = pickup.ConsumeIt();
                            if (success)
                            {
                                if (item.IsStackable())
                                {
                                    pickup.ReduceQuantity();
                                    if(pickup.GetQuantity() <= 0)
                                    {
                                        ResetPlayerState(pickup.gameObject);
                                    }
                                }
                                else
                                {
                                    ResetPlayerState(pickup.gameObject);
                                }
                            }
                            else
                            {
                                Debug.Log("Failed");
                            }
                        }
                    }
                }
            }
        }
        void ResetPlayerState(GameObject obj)
        {
            Destroy(obj);
            PlayerInteractionData.Instance.PlayerState = PlayerStates.HOLDNOTHING;
            PlayerInteractionData.Instance.CurrentHoldingObject = null;
        }
    }
}