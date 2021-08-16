using UnityEngine;
using UnityEngine.UI;
public class NavigationSignCountUI : MonoBehaviour
{
    [SerializeField] Text count;
    [SerializeField] PowerUp sign;

    private void OnEnable()
    {
        UpdateCount(sign.currentPowerUpCount);
    }

    public void UpdateCount(int value)
    {
        count.text = value.ToString();
    }
}
