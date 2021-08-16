using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PointsData", fileName = "NewPointsData")]
public class PointsData : ScriptableObject
{
    public enum PointsType
    {
        BLUEDIAMOND,
        GREENDIAMOND,
        PINKDIAMOND,
        REDDIAMOND,
        GOLDCOIN
    }
    public PointsType type;
    public int PointValue;
    public int quantity;
}
