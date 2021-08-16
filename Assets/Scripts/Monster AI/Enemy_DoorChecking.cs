using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_DoorChecking : MonoBehaviour
{
    [SerializeField] float startYOffset;
    [SerializeField] float rayDistance;
    [SerializeField] LayerMask doorLayer;

    RaycastHit hit;
    bool hitted;

    Vector3 startOffset;
    private void Start()
    {
        startOffset = new Vector3(0, startYOffset, 0);
    }
    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position + startOffset, transform.forward * rayDistance, Color.red);
        if (Physics.Raycast(transform.position + startOffset, transform.forward, out hit, rayDistance, doorLayer))
        {
            if (hit.collider.transform.root.gameObject.CompareTag("Door"))
            {
                hitted = true;
            }
            else
            {
                hitted = false;
            }
        }
        else
        {
            hitted = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (hitted && gameObject.CompareTag("ChasingPlayer"))
        {
            DoorObject door = hit.collider.GetComponentInParent<DoorObject>();
            if(door != null)
            {
                if (door.StateOfDoor.Equals(ObjectState.CLOSED) && door.StateOfInteraction.Equals(InteractionState.UNLOCKED))
                {
                    door.OnMonsterInteract(this.gameObject);
                }
            }
        }
    }
}
