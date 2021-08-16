using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyExploration.Interaction;
using MyExploration.Examine;
public class PlayerExaminationData 
{
    private static PlayerExaminationData m_instance =  new PlayerExaminationData();

    public static PlayerExaminationData Instance => m_instance;

    private InteractableObject m_currentExaminationObject;

    private Transform m_examiningPlace;

    private bool m_isExamining;


    public bool IsExamining
    {
        get => m_isExamining;
        set => m_isExamining = value;
    }
    public InteractableObject CurrentExaminationObject
    {
        get
        {
            if (PlayerInteractionData.Instance.AmIHoldSomething())
            {
                return m_currentExaminationObject = PlayerInteractionData.Instance.CurrentHoldingObject;
            }
            return null;
        }
    }

    public Transform ExaminingPlace
    {
        get => m_examiningPlace;
        set => m_examiningPlace = value;
    }
    public void Examine()
    {
        m_currentExaminationObject.GetComponent<IExaminable>().OnExamine();
    }
    public void UnExamine()
    {
        m_currentExaminationObject.GetComponent<IExaminable>().AfterExamined();
    }

    public void ResetData()
    {
        m_examiningPlace = null;
        m_isExamining = false;
        m_currentExaminationObject = null;
    }
}
