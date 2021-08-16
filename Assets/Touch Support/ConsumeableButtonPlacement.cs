using UnityEngine;

public class ConsumeableButtonPlacement : MonoBehaviour
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
            if (obj != null && PlayerInteractionData.Instance.IsConsumable)
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
    public void Active(bool value)
    {
        transform.GetChild(0).gameObject.SetActive(value);
    }
    public bool ActiveChildSelf()
    {
        return transform.GetChild(0).gameObject.activeSelf;
    }
}
