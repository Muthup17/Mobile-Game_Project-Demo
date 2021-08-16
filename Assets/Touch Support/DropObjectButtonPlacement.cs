using MyExploration.Inventories;
using UnityEngine;

public class DropObjectButtonPlacement : MonoBehaviour
{
    private void Start()
    {
        Active(false);
    }
    private void Update()
    {
        if (PlayerInteractionData.Instance.AmIHoldSomething())
        {
            var obj = PlayerInteractionData.Instance.CurrentHoldingObject;
            if (obj != null)
            {
                if (!ActiveChildSelf())
                {
                    Active(true);
                }
            }
            else
            {
                if (ActiveChildSelf())
                    Active(false);
            }
        }
        else
        {
            if (ActiveChildSelf())
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
