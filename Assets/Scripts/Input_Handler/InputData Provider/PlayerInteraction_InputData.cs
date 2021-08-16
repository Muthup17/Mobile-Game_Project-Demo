using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction_InputData
{
    private static PlayerInteraction_InputData m_instance = new PlayerInteraction_InputData();
    public static PlayerInteraction_InputData Instance { get { return m_instance; } }

    bool m_interacting;
    bool m_interactionKeyPressed;
    bool m_interactionKeyHolded;
    bool m_pickupKeyPressed;
    public bool Interacting
    {
        get => m_interacting;
        set => m_interacting = value;
    }

    public bool InteractionKeyPressed
    {
        get => m_interactionKeyPressed;
        set => m_interactionKeyPressed = value;
    }

    public bool InteractionKeyHolded
    {
        get => m_interactionKeyHolded;
        set => m_interactionKeyHolded = value;
    }

    public bool PickupKeyPressed
    {
        get => m_pickupKeyPressed;
        set => m_pickupKeyPressed = value;
    }

    public void ResetInput()
    {
        m_interacting = false;
        m_interactionKeyPressed = false;
        m_interactionKeyHolded = false;
        m_pickupKeyPressed = false;
    }
}
