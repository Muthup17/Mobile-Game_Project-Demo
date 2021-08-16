using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyExploration.Examine;
public class PlayerExamination_InputData
{
    private static PlayerExamination_InputData m_instance = new PlayerExamination_InputData();
    public static PlayerExamination_InputData Instance => m_instance;

    private bool m_examinationButtonIsHolding;
    private bool m_examinationButtonReleased;
    private Vector2 m_inputVector;
    public bool ExaminationButtonisHolding
    {
        get => m_examinationButtonIsHolding;
        set => m_examinationButtonIsHolding = value;
    }
    public bool ExaminationButtonReleased
    {
        get => m_examinationButtonReleased;
        set => m_examinationButtonReleased = value;
    }

    public Vector2 InputVector => m_inputVector;
    public float InputVectorX
    {
        set => m_inputVector.x = value;
    }

    public float InputVectorY
    {
        set => m_inputVector.y = value;
    }

    public void ResetInput()
    {
        m_examinationButtonIsHolding = false;
        m_inputVector = Vector2.zero;
        m_examinationButtonReleased = false;
    }
}
