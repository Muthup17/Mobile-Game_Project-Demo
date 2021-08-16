using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPointPickUp_InputData 
{
    private static PlayerPointPickUp_InputData m_instance = new PlayerPointPickUp_InputData();
    public static PlayerPointPickUp_InputData Instance => m_instance;

    private bool m_isPicked;

    private bool m_isExamineKeyHolded;
    public bool IsKeyPressed
    {
        get => m_isPicked;
        set => m_isPicked = value;
    }

    public bool IsExamineKeyHolded
    {
        get => m_isExamineKeyHolded;
        set => m_isExamineKeyHolded = value;
    }

    public void ResetInput()
    {
        m_isPicked = false;
        m_isExamineKeyHolded = false;
    }
}
