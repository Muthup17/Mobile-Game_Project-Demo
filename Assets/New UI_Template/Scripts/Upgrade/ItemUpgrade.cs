using UnityEngine;
using System;
public enum Level
{
    LEVEL1,
    LEVEL2,
    LEVEL3,
    LEVEL4,
    LEVEL5
}
[System.Serializable]
public class UpgradeLevel
{
    public Level level;
    public int requiredAmountForNextLevel;
    public string Description;
    public int increasePower;
}
[CreateAssetMenu(menuName = "Inventory/Upgrade", fileName = "UpgradeItem", order = 2)]
public class ItemUpgrade : ScriptableObject
{
    [SerializeField] Level currentLevel;
    [SerializeField] int currentLevelIndex;
    [SerializeField] int currentPower;
    [SerializeField] UpgradeLevel[] levels;

    public int CurrentPower => currentPower;
    public string currentDescription;
    public bool UpgradeToNextLevel(int playerPoint, out int redusingAmount)
    {
        int nextUpgradeIndex = currentLevelIndex + 1;
        if(nextUpgradeIndex <= levels.Length - 1)
        {
            if (levels[nextUpgradeIndex].requiredAmountForNextLevel <= playerPoint && currentLevel < levels[nextUpgradeIndex].level)
            {
                redusingAmount = levels[nextUpgradeIndex].requiredAmountForNextLevel;
                currentLevel = levels[nextUpgradeIndex].level;
                currentPower = levels[nextUpgradeIndex].increasePower;
                currentDescription = levels[nextUpgradeIndex].Description;
                currentLevelIndex = nextUpgradeIndex;
                return true;
            }
            else
            {
                redusingAmount = 0;

                Debug.Log("Not have Enough Money");
                return false;
            }
        }
        else
        {
            redusingAmount = 0;
            Debug.Log("Upgradation is full");
            return false;
        }
    }
}
