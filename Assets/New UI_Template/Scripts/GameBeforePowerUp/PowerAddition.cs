using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using LevelManagement;
public class PowerAddition : MonoBehaviour
{
    public PowerUp power;
    [SerializeField] Text tittle;
    [SerializeField] Text total;
    [SerializeField] Sprite icon;

    private void OnEnable()
    {
        StartCoroutine(WaitSomeTimetoCall());
    }
    public void AddPowerCount()
    {
        bool added = power.BuyPower(GamePointsManager.Instance.GamePoints);
        if (added)
        {
            GamePointsManager.Instance.DeleteGamePoint(power.powerUpValue);
            Dungeon1_LevelMenu.Instance.UpdateGamePoint(GamePointsManager.Instance.GamePoints);
            UpdateTotal();
        }
    }
    private void UpdateTotal()
    {
        if(tittle != null && !tittle.text.Equals(power.tittle))
        {
            tittle.text = power.tittle;
        }
        total.text = power.currentPowerUpCount.ToString();
    }

    public void UpdateTotalAtMenu()
    {
        MainMenu.Instance.UpdateNavigationSignCountUI(power.currentPowerUpCount);
    }

    IEnumerator WaitSomeTimetoCall()
    {
        yield return null;
        if (power != null)
        {
            UpdateTotal();
        }
    }
}
