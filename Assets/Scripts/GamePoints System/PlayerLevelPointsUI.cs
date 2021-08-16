using UnityEngine.UI;
using UnityEngine;

public class PlayerLevelPointsUI : MonoBehaviour
{
    [SerializeField] Text blueDiamondCount;
    [SerializeField] Text greenDiamondCount;
    [SerializeField] Text pinkDiamondCount;
    [SerializeField] Text goldCoinCount;

    private void Awake()
    {
        PlayerLevelPoints.OnDiamondAdded += AddPointsToUI;
    }

    private void Start()
    {
        blueDiamondCount.text = 0.ToString();
        greenDiamondCount.text = 0.ToString();
        pinkDiamondCount.text = 0.ToString();
        goldCoinCount.text = 0.ToString();
    }
    void AddPointsToUI(PointsData data)
    {
        switch (data.type)
        {
            case PointsData.PointsType.BLUEDIAMOND:
                blueDiamondCount.text = (int.Parse(blueDiamondCount.text) + data.quantity).ToString();
                break;
            case PointsData.PointsType.GREENDIAMOND:
                greenDiamondCount.text = (int.Parse(greenDiamondCount.text) + data.quantity).ToString();
                break;
            case PointsData.PointsType.PINKDIAMOND:
                pinkDiamondCount.text = (int.Parse(pinkDiamondCount.text) + data.quantity).ToString();
                break;
            case PointsData.PointsType.GOLDCOIN:
                goldCoinCount.text = (int.Parse(goldCoinCount.text) + data.quantity).ToString();
                break;
        }
    }

    private void OnDestroy()
    {
        PlayerLevelPoints.OnDiamondAdded -= AddPointsToUI;
    }
}
