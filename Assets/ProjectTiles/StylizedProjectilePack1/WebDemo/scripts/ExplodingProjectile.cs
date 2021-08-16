using UnityEngine;
using System.Collections;

/* THIS CODE IS JUST FOR PREVIEW AND TESTING */
// Feel free to use any code and picking on it, I cannot guaratnee it will fit into your project
public class ExplodingProjectile : MonoBehaviour
{
    [SerializeField] GameObject impactPrefab;
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] Rigidbody thisRigidbody;
    [SerializeField] bool LookRotation = true;
    [SerializeField] bool explodeOnTimer = false;
    [SerializeField] float explosionTimer;
    float timer;

    // Use this for initialization
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= explosionTimer && explodeOnTimer == true)
        {
            Explode();
        }

    }

    void FixedUpdate()
    {
        if (LookRotation && timer >= 0.05f)
        {
            transform.rotation = Quaternion.LookRotation(thisRigidbody.velocity);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, contact.normal);
            Vector3 pos = contact.point;
            GameObject impact = Instantiate(impactPrefab, pos, rot);
            impact.transform.SetParent(collision.gameObject.transform);
            Destroy(gameObject);
        }
        else
        {
            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, contact.normal);
            Vector3 pos = contact.point;
            Instantiate(impactPrefab, pos, rot);
            Destroy(gameObject);
        }
    }

    void Explode()
    {
        Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
        Destroy(gameObject);
    }

}