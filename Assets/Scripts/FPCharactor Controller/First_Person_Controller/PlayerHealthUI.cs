using UnityEngine.UI;
using UnityEngine;

[DefaultExecutionOrder(10)]
public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] ItemUpgrade upgrade;
    [SerializeField] Image playerHealth;
    float normalwidth = 400f; 
    private void Awake()
    {
        PlayerHealthSystem.Instance.OnPlayerHealthChange += UpdateHealth;
        SetHealthBarSize();
    }

    void UpdateHealth(float currHealth, float maxHealth)
    {
        float remapedHealthValue = Remap(currHealth, maxHealth);
        playerHealth.fillAmount = remapedHealthValue;
    }
    float Remap(float value, float maxValue)
    {
        return (value / maxValue) * 1;
    }
    private void OnDestroy()
    {
        PlayerHealthSystem.Instance.OnPlayerHealthChange -= UpdateHealth;
    }
    void SetHealthBarSize()
    {
        RectTransform rectTransform = this.GetComponent<RectTransform>();
        rectTransform.sizeDelta =  new Vector2(normalwidth + (upgrade.CurrentPower * 2), rectTransform.sizeDelta.y);
    }
}
