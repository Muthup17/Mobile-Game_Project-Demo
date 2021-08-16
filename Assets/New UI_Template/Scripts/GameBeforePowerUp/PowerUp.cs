using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUp", fileName = "Create PowerUp", order = 7)]
public class PowerUp : ScriptableObject
{
    [SerializeField] Sprite icon;
    public int powerUpValue;
    public int currentPowerUpCount;
    public string tittle;
    public GameObject prefab;
    public bool BuyPower(int playerPoint)
    {
        if(playerPoint > powerUpValue)
        {
            currentPowerUpCount++;
            return true;
        }
        else
        {
            Debug.Log("Not Having Enough Money");
            return false;
        }
    }
}
