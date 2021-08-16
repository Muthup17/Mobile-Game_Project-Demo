using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyExploration.Interaction;
public class RaycastManager : MonoBehaviour
{
    [SerializeField] private float m_rayDistance;
    [SerializeField] private float m_castRadius;
    [SerializeField] private LayerMask m_interactableLayer;
    [SerializeField] private LayerMask m_putbackLayer;
    [SerializeField] private LayerMask m_hitEveryThing;

    GameObject m_crosshair;
    Ray ray;
    RaycastHit hit1;
    RaycastHit hit2;
    bool isHitingPoints;
    bool isHittingInteractable;
    private void Awake()
    {
        if (m_crosshair == null)
        {
            m_crosshair = GameObject.FindGameObjectWithTag("Crosshair");
        }
    }
    private void FixedUpdate()
    {

        ray = Camera.main.ScreenPointToRay(m_crosshair.transform.position);
        FindPlayerInteractables();
        FindEverything();

    }
    void FindPlayerInteractables()
    {
        if (Physics.SphereCast(ray, m_castRadius, out hit1, m_rayDistance, m_interactableLayer))
        {
            GameObject hitObject = hit1.collider.gameObject;
            isHittingInteractable = hitObject.CompareTag("Interactable_Object");
            isHitingPoints = hitObject.CompareTag("Points_Object");

            if (isHittingInteractable)
            {
                Debug.DrawRay(ray.origin, ray.direction * m_rayDistance, Color.blue);
                InteractableObject obj = hit1.collider.GetComponentInParent<InteractableObject>();
                if (obj != null && PlayerInteractionData.Instance.isEmptyinteractabe())
                {
                    PlayerInteractionData.Instance.CurrentInteractableObject = obj;
                }
                else
                {
                    if (PlayerInteractionData.Instance.SameInteractableObj(obj))
                    {
                        return;
                    }
                    else
                    {
                        PlayerInteractionData.Instance.CurrentInteractableObject = obj;
                    }
                }
            }
            else if (isHitingPoints)
            {
                PointsPickUp pickUp = hit1.collider.GetComponentInParent<PointsPickUp>();
                if (pickUp != null && Player_PointsData.Instance.IsEmptyPointsData())
                {
                    Player_PointsData.Instance.CurrentHittingPointsData = pickUp;
                }
                else
                {
                    if (Player_PointsData.Instance.SamePickUpObj(pickUp))
                    {
                        return;
                    }
                    else
                    {
                        Player_PointsData.Instance.CurrentHittingPointsData = pickUp;
                    }
                }
            }
        }
        else
        {
            isHittingInteractable = false;
            isHitingPoints = false;
            PlayerInteractionData.Instance.CurrentInteractableObject = null;
            Player_PointsData.Instance.CurrentHittingPointsData = null;
        }
        PlayerInteractionData.Instance.ReadyToInteract = isHittingInteractable;
        Player_PointsData.Instance.ReadyToPickUp = isHitingPoints;
    }
    void FindEverything()
    {
        if (Physics.Raycast(ray, out hit2, m_rayDistance * 100, m_hitEveryThing))
        {
            Debug.DrawRay(ray.origin, ray.direction * m_rayDistance * 100, Color.red);
            PlayerInteractionData.Instance.HitEveryThingRayHitPoint = hit2.point;

        }
        else
        {
            PlayerInteractionData.Instance.HitEveryThingRayHitPoint = Vector3.zero;
        }
    }
}
