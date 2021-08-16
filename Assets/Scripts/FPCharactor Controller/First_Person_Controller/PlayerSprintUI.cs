using PlayerControlls;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(10)]
public class PlayerSprintUI : MonoBehaviour
{
    [SerializeField] ItemUpgrade upgrade;
    [SerializeField] Image fill;
    float normalwidth = 400f;

    private void Awake()
    {
        PlayerSprintSystem.Instance.OnPlayerSprintChange += SetSprintUI;
    }
    // Start is called before the first frame update
    void Start()
    {
        SetSprintBarSize();
    }

    void SetSprintUI(float amount)
    {
        fill.fillAmount = amount;
    }
    void SetSprintBarSize()
    {
        RectTransform rectTransform = this.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(normalwidth + (upgrade.CurrentPower * 2), rectTransform.sizeDelta.y);
    }
    private void OnDestroy()
    {
        PlayerSprintSystem.Instance.OnPlayerSprintChange -= SetSprintUI;
    }
}
