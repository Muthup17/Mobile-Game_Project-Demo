using System;
using UnityEngine;

public class PlayerDamageByShoot : MonoBehaviour
{
    [SerializeField] float minDamageRate;
    [SerializeField] float maxDamageRate;
    [SerializeField] float camshakeAmount = 0.2f;
    [SerializeField] float camShakeDuration = 0.3f;
    private float currentDamage;

    public static event Action<float> OnProjectileHit;
    public static event Action<float, float> OnPlayerReceiveDamageByShoot;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Called");
            currentDamage = UnityEngine.Random.Range(minDamageRate, maxDamageRate);
            OnProjectileHit?.Invoke(currentDamage);
            OnPlayerReceiveDamageByShoot?.Invoke(camshakeAmount, camShakeDuration);
        }
    }
}
