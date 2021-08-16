using MyExploration.Inventories;
using System.Collections;
using System;
using UnityEngine;


namespace MyExploration.Interaction
{
    public enum PlayerStates
    {
        HOLDNOTHING,
        HOLDING,
        EXAMINING
    }
    public class InteractionManager : MonoBehaviour
    {
        [SerializeField] private PlayerStates m_playerState;
        [SerializeField] private Transform m_holdingAnchor;
        [SerializeField] private Transform m_weaponAnchor;

        public static event Action OnHoldingInteractionProgress;
        void Start()
        {
            m_playerState = PlayerStates.HOLDNOTHING;
            PlayerInteractionData.Instance.HoldingAnchor = m_holdingAnchor;
            PlayerInteractionData.Instance.WeaponAnchor = m_weaponAnchor;

            PlayerInteractionData.Instance.PlayerState = m_playerState;
        }
        void Update()
        {
            m_playerState = PlayerInteractionData.Instance.PlayerState;
            DoInteract();
        }

        void DoInteract()
        {
            switch (m_playerState)
            {
                case PlayerStates.HOLDNOTHING:
                    if (!PlayerInteractionData.Instance.ReadyToInteract) return;
                    if (PlayerInteractionData.Instance.CurrentInteractableObject.TypeOfButtonAction.Equals(ButtonActionType.HOLDABLE))
                    {
                        if (PlayerInteraction_InputData.Instance.InteractionKeyHolded)
                        {
                            PlayerInteractionData.Instance.CurrentInteractableObject.CurrentAccessTime += Time.deltaTime;
                            if (PlayerInteractionData.Instance.CurrentInteractableObject.CurrentAccessTime >= PlayerInteractionData.Instance.CurrentInteractableObject.AccessTime)
                                PlayerInteractionData.Instance.Interact();
                        }
                        else
                        {
                            PlayerInteractionData.Instance.CurrentInteractableObject.CurrentAccessTime = 0;
                        }
                        OnHoldingInteractionProgress?.Invoke();
                    }
                    else
                    {
                        if (PlayerInteraction_InputData.Instance.InteractionKeyPressed)
                        {
                            PlayerInteractionData.Instance.Interact();
                        }
                    }
                    break;

                case PlayerStates.HOLDING:
                    if (!PlayerInteractionData.Instance.ReadyToInteract)
                    {
                        if (PlayerInteraction_InputData.Instance.InteractionKeyPressed)
                        {
                            PlayerInteractionData.Instance.CurrentHoldingObject.GetComponent<PickableObject>().UnHoldTheObject();
                        }
                    }
                    else
                    {
                        CheckHandConstraint();
                    }
                    if (PlayerInteraction_InputData.Instance.PickupKeyPressed)
                    {
                        PlayerInteractionData.Instance.CurrentHoldingObject.gameObject.GetComponent<Pickup>().PickupItem();
                    }
                    break;

                case PlayerStates.EXAMINING:
                    return;
            }
        }

        void CheckHandConstraint()
        {
            if (PlayerInteractionData.Instance.CurrentInteractableObject.TypeOfObject.Equals(ObjectType.ONEHANDED))
            {
                if (PlayerInteractionData.Instance.CurrentInteractableObject.TypeOfButtonAction.Equals(ButtonActionType.HOLDABLE))
                {
                    if (PlayerInteraction_InputData.Instance.InteractionKeyHolded && PlayerInteractionData.Instance.CurrentInteractableObject.GetType().Equals(typeof(Chest)))
                    {
                        PlayerInteractionData.Instance.CurrentInteractableObject.CurrentAccessTime += Time.deltaTime;
                        if (PlayerInteractionData.Instance.CurrentInteractableObject.CurrentAccessTime >= PlayerInteractionData.Instance.CurrentInteractableObject.AccessTime)
                            PlayerInteractionData.Instance.Interact();
                    }
                    else
                    {
                        PlayerInteractionData.Instance.CurrentInteractableObject.CurrentAccessTime = 0;
                    }
                    OnHoldingInteractionProgress?.Invoke();
                }
                else
                {
                    if (PlayerInteraction_InputData.Instance.InteractionKeyPressed && PlayerInteractionData.Instance.CurrentInteractableObject.GetType().Equals(typeof(DoorObject)))
                    {
                        PlayerInteractionData.Instance.Interact();
                    }
                    else if (PlayerInteraction_InputData.Instance.InteractionKeyPressed)
                    {
                        PlayerInteractionData.Instance.CurrentHoldingObject.GetComponent<PickableObject>().UnHoldTheObject();
                        PlayerInteractionData.Instance.Interact();
                    }
                }   
            }
            else
            {
                Debug.Log("Need To Drop the Currently Holding object");
            }
        }

/*        [SerializeField] private GameObject m_crosshair;
        [SerializeField] private float m_rayDistance;
        [SerializeField] private float m_castRadius;
        [SerializeField] private LayerMask m_putBackLayer;
        Ray ray;
        RaycastHit hitOfPutBackLocation;
        bool isHittingPutBackLocation;*/
        void FindPutBackLocation()
        {
/*            if (!PlayerInteractionData.Instance.AmIHoldSomething()) return;
            ray = Camera.main.ScreenPointToRay(m_crosshair.transform.position);
            isHittingPutBackLocation = Physics.Raycast(ray, out hitOfPutBackLocation, m_rayDistance, m_putBackLayer);
            if (isHittingPutBackLocation)
            {
                Transform putTransform = hitOfPutBackLocation.collider.gameObject.transform;
                if (putTransform != null && PlayerInteractionData.Instance.isEmptyPutBackTransform())
                {
                    PlayerInteractionData.Instance.PutBackTransform = putTransform;
                }
                else
                {
                    if (PlayerInteractionData.Instance.SamePutBackTransform(putTransform))
                    {
                        return;
                    }
                    else
                    {
                        PlayerInteractionData.Instance.PutBackTransform = putTransform;
                    }
                }
            }
            else
            {
                PlayerInteractionData.Instance.PutBackTransform = null;
                return;
            }*/
        }

        private void OnDisable()
        {
            PlayerInteractionData.Instance.ResetData();
        }
    }
}
