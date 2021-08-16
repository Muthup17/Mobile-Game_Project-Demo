using System;
using System.Collections;
using UnityEngine;

public class MonsterDamageByMelee : MonoBehaviour
{
    [SerializeField] float minDamageRate;
    [SerializeField] float maxDamageRate;
    [SerializeField] float swordSweepAnimationLength = 0.667f;

    private float currentDamage;

    public static event Action<GameObject, float> OnSwordHitMonster;
    bool hitted;
    // Start is called before the first frame update
    void Start()
    {
        hitted = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster") && !hitted)
        {
            Debug.Log("Called");
            currentDamage = UnityEngine.Random.Range(minDamageRate, maxDamageRate);
            OnSwordHitMonster?.Invoke(other.transform.parent.gameObject ,currentDamage);
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
