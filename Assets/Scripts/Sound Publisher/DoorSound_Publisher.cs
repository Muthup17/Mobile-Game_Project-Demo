using System;
using UnityEngine;
public class DoorSound_Publisher : MonoBehaviour
{
    [SerializeField] LayerMask monsterLayer;
    [SerializeField] LayerMask obstacleLayer;
    [SerializeField] float publishing_Radius;
    [SerializeField] float yOffset;
    DoorObject door;

    public static event Action<GameObject, GameObject> onDoorOpenSoundHear;

    private void Awake()
    {
        door = GetComponentInChildren<DoorObject>();
    }
    // Update is called once per frame
    void Update()
    {
        Collider[] subscribers = Physics.OverlapSphere(transform.position + new Vector3(0, yOffset, 0), publishing_Radius, monsterLayer);
        foreach (Collider sub in subscribers)
        {
            if (sub.CompareTag("Base"))
            {
                Transform CurrTarget = sub.transform;
                Vector3 dirToTarget = (CurrTarget.position - transform.position).normalized;
                float dstToTarget = Vector3.Distance(transform.position, CurrTarget.position);
                if (!Physics.Raycast(transform.position + new Vector3(0, yOffset, 0), dirToTarget, dstToTarget, obstacleLayer))
                {
                    Debug.DrawRay(transform.position + new Vector3(0, yOffset, 0), dirToTarget * dstToTarget, Color.green);
                    if (door.doorOpenSoundPlayed)
                    {
                        onDoorOpenSoundHear?.Invoke(sub.transform.parent.gameObject, this.gameObject);
                    }
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position + new Vector3(0, yOffset, 0), publishing_Radius);
    }
}
