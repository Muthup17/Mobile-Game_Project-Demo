using UnityEngine;
using UnityEngine.UI;
using MyExploration.Interaction;

namespace MyExploration.UI.Interactions
{
    public class InteractionProgressBar : MonoBehaviour
    {

        [SerializeField] Image fill;
        [SerializeField] Image foreGround;
        private void Awake()
        {
            InteractionManager.OnHoldingInteractionProgress += HoldingInteractionProgress;
        }
        // Start is called before the first frame update
        void Start()
        {
            fill.fillAmount = 0;
            SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (PlayerInteractionData.Instance.CurrentInteractableObject != null && PlayerInteractionData.Instance.CurrentInteractableObject.TypeOfButtonAction.Equals(ButtonActionType.HOLDABLE))
            {
                if (PlayerInteraction_InputData.Instance.InteractionKeyHolded)
                {
                    if(!GetActiveSelf(fill.gameObject, foreGround.gameObject))
                    {
                        SetActive(true);
                    }
                }
                else
                {
                    if (GetActiveSelf(fill.gameObject, foreGround.gameObject))
                    {
                        SetActive(false);
                    }
                }
            }
            else
            {
                if (GetActiveSelf(fill.gameObject, foreGround.gameObject))
                {
                    SetActive(false);
                }
            }
        }

        void HoldingInteractionProgress()
        {
            float value = PlayerInteractionData.Instance.CurrentInteractableObject.CurrentAccessTime;
            float maxValue = PlayerInteractionData.Instance.CurrentInteractableObject.AccessTime;
            fill.fillAmount = Normalize(value, maxValue);
        }
        float Normalize(float inputValue, float maxValue)
        {
            return inputValue / maxValue;
        }

        private void OnDestroy()
        {
            InteractionManager.OnHoldingInteractionProgress -= HoldingInteractionProgress;
        }

        void SetActive(bool value)
        { 
            fill.gameObject.SetActive(value);
            foreGround.gameObject.SetActive(value);
        }
        bool GetActiveSelf(GameObject obj1, GameObject obj2)
        {
            return obj1.activeSelf && obj2.activeSelf;
        }
    }
}
