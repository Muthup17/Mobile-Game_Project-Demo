using System.Collections;
using UnityEngine;

public class Rat_Spawner : MonoBehaviour
{
    [SerializeField] GameObject rat;
    [SerializeField] float waitDuration;
    [SerializeField] Vector3 viewPortPoint;
    bool called;

    private void Start()
    {
        called = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground") && !called)
        {
            StartCoroutine(SpawnRat());
            called = true;
        }
    }

    IEnumerator SpawnRat()
    {
        yield return new WaitForSeconds(waitDuration);
        Spawn();
    }

    void Spawn()
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(viewPortPoint);
        GameObject ratAgent = Instantiate(rat, pos, Quaternion.identity);
        ratAgent.GetComponent<GOAP_Agent>().inventory.AddItem(this.gameObject);
    }
}
