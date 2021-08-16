using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_PointsPickupManager : MonoBehaviour
{
    [SerializeField] PlayerLevelPoints levelPoints;

    private void Awake()
    {
        if(levelPoints == null)
        {
            levelPoints = GetComponent<PlayerLevelPoints>();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Player_PointsData.Instance.LevelPoints = levelPoints;
    }

    void Update()
    {
        if (Player_PointsData.Instance.ReadyToPickUp)
        {
            if (PlayerPointPickUp_InputData.Instance.IsKeyPressed)
            {
                Player_PointsData.Instance.OnPickUp();
            }
        }
    }

    private void OnDisable()
    {
        Player_PointsData.Instance.ResetData();
    }
}
