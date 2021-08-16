using MyExploration.Inventories;
using UnityEngine;

public class PowerUpItemSpawner : MonoBehaviour
{
    [SerializeField] PowerUp[] items;
    [SerializeField] Transform spwanTransform;
    private void Start()
    {
        for(int i = 0; i < items.Length; i++)
        {
            GameObject item = Instantiate(items[i].prefab, spwanTransform.position, Quaternion.identity);
            item.GetComponent<Pickup>().SetQuantity(items[i].currentPowerUpCount);
            items[i].currentPowerUpCount = 0;
        }
    }
}
