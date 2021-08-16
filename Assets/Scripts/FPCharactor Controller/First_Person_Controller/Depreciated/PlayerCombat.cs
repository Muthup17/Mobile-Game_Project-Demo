using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyExploration.Interaction;
public class PlayerCombat : MonoBehaviour
{
    Animator anim;
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (PlayerInteractionData.Instance.PlayerState.Equals(PlayerStates.HOLDING))
        {
            var weapon = PlayerInteractionData.Instance.CurrentHoldingObject.GetComponent<IWeaponable>();
            if (weapon == null) return;
            if (PlayerMovement_InputData.Instance.ShootPressed && weapon.TypeOfWeapon.Equals(WeaponType.MELEE))
            {
                float randomValue = Random.Range(0, 100);
                if(randomValue < 25)
                {
                    anim.SetTrigger("Sweep 1");
                }
                else if(randomValue > 25 && randomValue < 50)
                {
                    anim.SetTrigger("Sweep 2");
                }
                else
                {
                    anim.SetTrigger("Sweep 3");
                }
            }
        }
    }
}
