using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyExploration.Interaction;
public class PlayerInteractionData
{
    private static PlayerInteractionData m_instance = new PlayerInteractionData();
    public static PlayerInteractionData Instance => m_instance;

    #region Private fields
    private PlayerStates m_playerState;

    private InteractableObject m_currentInteractableObject;

    private InteractableObject m_currentHoldingObject;

    private bool m_readyToInteract;

    private bool m_readyToPutBack;

    private Transform m_putBackTransform;

    private Vector3 m_hitEveryThingRayHitPoint;

    private bool m_isConsumable;

    private Transform m_holdingAnchor;
    private Transform m_weaponAnchor;

    #endregion

    #region Properties

    public PlayerStates PlayerState
    {
        get => m_playerState;
        set => m_playerState = value;
    }

    public InteractableObject CurrentInteractableObject
    {
        get => m_currentInteractableObject;
        set => m_currentInteractableObject = value;
    }
    public bool IsConsumable
    {
        get => m_isConsumable;
        set => m_isConsumable = value;
    }
    public Transform HoldingAnchor { get => m_holdingAnchor; set => m_holdingAnchor = value; }
    public Transform WeaponAnchor { get => m_weaponAnchor; set => m_weaponAnchor = value; }
    public Vector3 HitEveryThingRayHitPoint { get => m_hitEveryThingRayHitPoint; set => m_hitEveryThingRayHitPoint = value; }

    public InteractableObject CurrentHoldingObject
    {
        get => m_currentHoldingObject;
        set => m_currentHoldingObject = value;
    }
    public bool ReadyToInteract
    {
        get => m_readyToInteract;
        set => m_readyToInteract = value;
    }
    public Transform PutBackTransform { get => m_putBackTransform; set => m_putBackTransform = value; }

    #endregion

    #region
    public bool SameInteractableObj(InteractableObject obj)
    {
        if (m_currentInteractableObject.Equals(obj))
        {
            return true;
        }
        return false;
    }

    public bool SamePutBackTransform(Transform t)
    {
        if (m_putBackTransform.Equals(t))
        {
            return true;
        }
        return false;
    }
    public bool isEmptyinteractabe()
    {
        if(m_currentInteractableObject == null)
        {
            return true;
        }
        return false;
    }

    public bool isEmptyPutBackTransform()
    {
        if(m_putBackTransform == null)
        {
            return true;
        }
        return false;
    }

    public bool AmIHoldSomething()
    {
        return m_currentHoldingObject != null ? true : false;
    }

    public bool ReadyToPutBack()
    {
        m_readyToPutBack = (!isEmptyPutBackTransform() && m_putBackTransform.gameObject.name.Contains(m_currentHoldingObject.gameObject.name)) ? true : false;
        return m_readyToPutBack;
    }
    public void Interact()
    {
        m_currentInteractableObject.OnInteract();
    }

    public void ResetData()
    {
        m_currentInteractableObject = null;
        m_currentHoldingObject = null;
        m_readyToInteract = false;
        m_isConsumable = false;
        m_readyToPutBack = false;
        m_putBackTransform = null;
        m_hitEveryThingRayHitPoint = Vector3.zero;
        m_holdingAnchor = null;
        m_weaponAnchor = null;
    }
    #endregion
}
