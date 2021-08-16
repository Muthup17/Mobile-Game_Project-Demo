using UnityEngine.UI;
using UnityEngine;
using MyExploration.Interaction;
public class InteractionInfoUI : MonoBehaviour
{
    [SerializeField] private Text informText;
    [SerializeField] private Text interactText;

    void Update()
    {
        informText.text = PlayerInteractionData.Instance.ReadyToInteract ? "Press X To Interact" : "";
        if (PlayerInteractionData.Instance.PlayerState == PlayerStates.HOLDING && !PlayerInteractionData.Instance.ReadyToInteract)
        {
            interactText.text = PlayerInteractionData.Instance.ReadyToPutBack() ? "PutBack" : "";
        }
        else
        {
            if (PlayerInteractionData.Instance.ReadyToInteract)
            {
                interactText.text = (!PlayerInteractionData.Instance.isEmptyinteractabe()) ? PlayerInteractionData.Instance.CurrentInteractableObject.GetDescriptionText : "";
            }
            else
            {
                interactText.text = (Player_PointsData.Instance.ReadyToPickUp && !Player_PointsData.Instance.IsEmptyPointsData()) ? "PickUp" : "";
            }
        }
    }
}
