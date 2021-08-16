using UnityEngine.UI;
using UnityEngine;

public class Upgradation : MonoBehaviour
{
    [SerializeField] ItemUpgrade itemUpgrade;
    [SerializeField] Text description;

    private void Start()
    {
        SetText();
    }
    public void Upgrade()
    {
        int redusingPoints = 0;
        bool success = itemUpgrade.UpgradeToNextLevel(GamePointsManager.Instance.GamePoints, out redusingPoints);
        if (success)
        {
            GamePointsManager.Instance.DeleteGamePoint(redusingPoints);
            SetText();
        }
        else
        {
            return;
        }
    }

    void SetText()
    {
        description.text = itemUpgrade.currentDescription;
    }
}
