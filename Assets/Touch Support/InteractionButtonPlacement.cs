using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionButtonPlacement : MonoBehaviour
{
    private void Start()
    {
        Active(false);
    }
    private void Update()
    {
        if (PlayerInteractionData.Instance.ReadyToInteract)
        {
            var obj = PlayerInteractionData.Instance.CurrentInteractableObject;
            if(obj != null)
            {
                if (!ActiveChildSelf())
                {
                    Active(true);
                }
                transform.position = Camera.main.WorldToScreenPoint(obj.TouchableButtonAnchor.position);
            }
            else
            {
                if (ActiveChildSelf())
                    Active(false);
            }
        }
        else if (Player_PointsData.Instance.ReadyToPickUp)
        {
            var obj = Player_PointsData.Instance.CurrentHittingPointsData;
            if (obj != null)
            {
                if (!ActiveChildSelf())
                {
                    Active(true);
                }
                transform.position = Camera.main.WorldToScreenPoint(obj.transform.position);
            }
            else
            {
                if (ActiveChildSelf())
                    Active(false);
            }
        }
        else
        {
            if(ActiveChildSelf())
                Active(false);
        }       
    }

    void Active(bool value)
    {
        transform.GetChild(0).gameObject.SetActive(value);
    }
    bool ActiveChildSelf()
    {
        return transform.GetChild(0).gameObject.activeSelf;
    }
}
