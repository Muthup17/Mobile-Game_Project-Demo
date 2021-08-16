using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationSign_PlacementData 
{
    private static NavigationSign_PlacementData m_instance = new NavigationSign_PlacementData();
    public static NavigationSign_PlacementData Instance => m_instance;

    private Vector3 m_signPlacePoint;

    private bool m_readyToPlaceSign;
    public Vector3 SignPlacePoint { get => m_signPlacePoint; set => m_signPlacePoint = value; }

    public bool ReadyToPlaceSign { get => m_readyToPlaceSign; set => m_readyToPlaceSign = value;}

    public bool SameSignPlacePoint(Vector3 point)
    {
        if (SignPlacePoint.Equals(point))
        {
            return true;
        }
        return false;
    }
    public void ResetData()
    {
        m_signPlacePoint = Vector3.zero;
        m_readyToPlaceSign = false;
    }
}
