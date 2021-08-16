using MyExploration.Inventories;
using UnityEngine;

public enum WeaponType
{
    MELEE,
    SHOOTABLE,
    ROCK
}
public interface IWeaponable
{
    public WeaponType TypeOfWeapon { get; }

    public GameObject ShootProjectile { get; }
    public int GetItemCount();
    public void ReduceCount();
}

public class WeaponObject : PickableObject, IWeaponable
{
    [SerializeField] Pickup pickup1;
    [SerializeField] ObjectBaseType baseType;
    [SerializeField] WeaponType weaponType;
    [SerializeField] GameObject shootProjectile;
    private int count;
    public WeaponType TypeOfWeapon => weaponType;

    public GameObject ShootProjectile => shootProjectile;
    public int GetItemCount()
    {
        if(pickup1 == null)
        {
            pickup1 = GetComponent<Pickup>(); ;
        }
        count = pickup1.GetQuantity();
        return count;
    }

    public override void HoldTheObject()
    {
        base.HoldTheObject();
        ShowTip();
    }
    public void ReduceCount()
    {
        count--;
        pickup1.SetQuantity(count);
    }

    void ShowTip()
    {
        switch (baseType)
        {
            case ObjectBaseType.ROCK:
                SetTip(4);
                break;
            case ObjectBaseType.CHEESE:
                SetTip(3);
                break;
            case ObjectBaseType.BOMB:
                SetTip(5);
                break;
        }
    }

    void SetTip(int i)
    {
        if (!UserLearningSystem.Instance.Learn.learnItems[i].value)
        {
            UserLearningSystem.Instance.tipRequested = true;
            UserLearningSystem.Instance.currentTipIndex = i;
        }
    }
    public enum ObjectBaseType
    {
        ROCK,
        CHEESE,
        BOMB
    }

}
