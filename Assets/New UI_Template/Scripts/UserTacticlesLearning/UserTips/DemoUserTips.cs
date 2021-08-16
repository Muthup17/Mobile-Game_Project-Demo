using UnityEngine;
using UnityEngine.UI;

public class DemoUserTips : MonoBehaviour
{
    [SerializeField] Text tittle;
    [SerializeField] Image image;
    [SerializeField] Text description;
    public GameObject content;
    public InteractableObjectTipDetails tip;
    private void OnEnable()
    {
        if (!tittle || !image || !description)
        {
            Debug.LogError("Set ref properly");
            return;
        }
        PlayerDemoLearningSystem.Instance.UserTipUI = this;
    }
    public void UpdateTipUI()
    {
        tittle.text = this.tip.displayName;
        /*        image.sprite = this.tip.displayImage;*/
        description.text = this.tip.description;
    }

    public void ShowUI()
    {
        UpdateTipUI();
    }

    public void HideUI()
    {
        PlayerDemoLearningSystem.Instance.HideTip();
    }
}
