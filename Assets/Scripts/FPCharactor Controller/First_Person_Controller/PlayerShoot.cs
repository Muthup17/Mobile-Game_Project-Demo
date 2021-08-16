using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyExploration.Interaction;
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject rockProjecttile;
    [SerializeField] Transform shootStartPlace;
    [SerializeField] float maxHeight;
    float initialHeight;
    // Start is called before the first frame update
    void Start()
    {
        initialHeight = maxHeight;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInteractionData.Instance.PlayerState.Equals(PlayerStates.HOLDING))
        {
            if (PlayerMovement_InputData.Instance.ShootPressed)
            {
                var weapon = PlayerInteractionData.Instance.CurrentHoldingObject.GetComponent<IWeaponable>();
                if (weapon == null) return;
                if (weapon.TypeOfWeapon.Equals(WeaponType.SHOOTABLE))
                {
                    Shoot(weapon, weapon.ShootProjectile);
                }
                else if (weapon.TypeOfWeapon.Equals(WeaponType.ROCK))
                {
                    Shoot(weapon, rockProjecttile);
                }
            }
        }
    }

    void Shoot(IWeaponable weapon, GameObject projectile)
    {
        if (weapon.GetItemCount() > 0)
        {
            Launch(projectile);
            weapon.ReduceCount();
            if (weapon.GetItemCount().Equals(0))
            {
                Destroy(PlayerInteractionData.Instance.CurrentHoldingObject.gameObject);
                PlayerInteractionData.Instance.PlayerState = PlayerStates.HOLDNOTHING;
            }
        }
    }

    public void Launch(GameObject projectile)
    {
        GameObject ball = Instantiate(projectile, shootStartPlace.position, Quaternion.identity);
        Rigidbody ballRB = ball.GetComponent<Rigidbody>();
        ballRB.velocity = Vector3.zero;
        ballRB.velocity = CalCulateLaunchForce(ballRB);
    }

    Vector3 CalCulateLaunchForce(Rigidbody rb)
    {
        maxHeight = initialHeight;
        Vector3 hitPoint = PlayerInteractionData.Instance.HitEveryThingRayHitPoint;
        float displacementY = (hitPoint.y) - rb.position.y;
        Vector3 displacementXZ = new Vector3(hitPoint.x - rb.position.x, 0, hitPoint.z - rb.position.z);
        if(displacementY > maxHeight)
        {
            maxHeight = displacementY;
        }
        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * Physics.gravity.y * maxHeight);
        Vector3 velocityXZ = displacementXZ / (Mathf.Sqrt(-2 * maxHeight / Physics.gravity.y) + Mathf.Sqrt(2 * (displacementY - maxHeight) / Physics.gravity.y));
        return velocityXZ + velocityY;
    }
}
