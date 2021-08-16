using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerLevelPoints : MonoBehaviour
{
    private List<PointsData> blueDiamonds;
    private List<PointsData> greenDiamonds;
    private List<PointsData> pinkDiamonds;
    private List<PointsData> goldCoins;

    public List<PointsData> BlueDiamonds => blueDiamonds;
    public List<PointsData> GreenDiamonds => greenDiamonds;
    public List<PointsData> PinkDiamonds => pinkDiamonds;
    public List<PointsData> GoldCoins => goldCoins;

    public static event Action<PointsData> OnDiamondAdded;
    // Start is called before the first frame update
    void Start()
    {
        blueDiamonds = new List<PointsData>();
        greenDiamonds = new List<PointsData>();
        pinkDiamonds = new List<PointsData>();
        goldCoins = new List<PointsData>();

        blueDiamonds.Clear();
        greenDiamonds.Clear();
        pinkDiamonds.Clear();
        goldCoins.Clear();
    }

    public void AddPoint(PointsData data)
    {
        int learnIndex = 0;
        switch (data.type)
        {
            case PointsData.PointsType.BLUEDIAMOND:
                learnIndex = 11;
                AddPointsToDiamondList(blueDiamonds, data);
                break;
            case PointsData.PointsType.GREENDIAMOND:
                learnIndex = 10;
                AddPointsToDiamondList(greenDiamonds, data);
                break;
            case PointsData.PointsType.PINKDIAMOND:
                learnIndex = 9;
                AddPointsToDiamondList(pinkDiamonds, data);
                break;
            case PointsData.PointsType.GOLDCOIN:
                learnIndex = 8;
                AddPointsToDiamondList(goldCoins, data);
                break;
        }
        if (!UserLearningSystem.Instance.Learn.learnItems[learnIndex].value)
        {
            UserLearningSystem.Instance.tipRequested = true;
            UserLearningSystem.Instance.currentTipIndex = learnIndex;
        }
        OnDiamondAdded?.Invoke(data);
    }

    void AddPointsToDiamondList(List<PointsData> datas, PointsData data)
    {
        if(data.quantity > 2)
        {
            PointsData refdata = ScriptableObject.CreateInstance<PointsData>();
            refdata.type = data.type;
            refdata.PointValue = data.PointValue;
            refdata.quantity = 1;
            for (int i = 0; i < data.quantity; i++)
            {
                datas.Add(refdata);
            }
        }
        else
        {
            datas.Add(data);
        }
    }
    public int CalculateGamePoints()
    {
        int blueValue = blueDiamonds.Count > 0 ? blueDiamonds.Count * blueDiamonds[0].PointValue : 0;
        int greenValue = greenDiamonds.Count > 0 ? greenDiamonds.Count * greenDiamonds[0].PointValue : 0;
        int pinkValue = pinkDiamonds.Count > 0 ? pinkDiamonds.Count * pinkDiamonds[0].PointValue : 0;
        int goldValue = goldCoins.Count > 0 ? goldCoins.Count * goldCoins[0].PointValue : 0;

        int total = blueValue + greenValue + pinkValue + goldValue;
        return total;
    }
}
