using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_PointsData 
{
    private static Player_PointsData m_instance = new Player_PointsData();

    public static Player_PointsData Instance => m_instance;

    private PointsPickUp m_currentHittingPointsData;

    private bool m_readyToPickUp;

    private PlayerLevelPoints m_playerLevelPoints;

    public PointsPickUp CurrentHittingPointsData
    {
        get => m_currentHittingPointsData;
        set => m_currentHittingPointsData = value;
    }
    public bool ReadyToPickUp
    {
        get => m_readyToPickUp;
        set => m_readyToPickUp = value;
    }

    public PlayerLevelPoints LevelPoints
    {
        get => m_playerLevelPoints;
        set => m_playerLevelPoints = value;
    }
    public bool SamePickUpObj(PointsPickUp obj)
    {
        if (m_currentHittingPointsData.Equals(obj))
        {
            return true;
        }
        return false;
    }

    public bool IsEmptyPointsData()
    {
        if (m_currentHittingPointsData == null)
        {
            return true;
        }
        return false;
    }

    public void OnPickUp()
    {
        CurrentHittingPointsData.PickUp(LevelPoints);
    }

    public void ResetData()
    {
        m_currentHittingPointsData = null;
        m_readyToPickUp = false;
        m_playerLevelPoints = null;
    }
}
