using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PointsPickUp : MonoBehaviour
{
    [SerializeField] PointsData data;

    public void PickUp(PlayerLevelPoints level)
    {
        level.AddPoint(data);
        Destroy(this.gameObject);
    }
}
