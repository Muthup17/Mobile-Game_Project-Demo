using System;
using System.Collections;
using UnityEngine;

public class PlayerDamageByMelee : MonoBehaviour
{
    [SerializeField] float minDamageRate;
    [SerializeField] float maxDamageRate;
    [SerializeField] float swordSweepAnimationLength = 1.5f;
    [SerializeField] float camshakeAmount = 0.15f;
    [SerializeField] float camShakeDuration = 0.2f;
    private float currentDamage;

    public static event Action<float> OnSwordHit;
    public static event Action<float, float> OnPlayerReceiveDamageByMelee;
    bool hitted;
    // Start is called before the first frame update
    void Start()
    {
        hitted = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hitted)
        {
            currentDamage = UnityEngine.Random.Range(minDamageRate, maxDamageRate);
            OnSwordHit?.Invoke(currentDamage);
            OnPlayerReceiveDamageByMelee?.Invoke(camshakeAmount, camShakeDuration);
            StartCoroutine(WaitToCompleteSweep());
        }

    }

    IEnumerator WaitToCompleteSweep()
    {
        hitted = true;
        yield return new WaitForSeconds(swordSweepAnimationLength);
        hitted = false;
    }
}
