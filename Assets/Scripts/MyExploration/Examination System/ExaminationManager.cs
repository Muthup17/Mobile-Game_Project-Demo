using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyExploration.Examine
{
    public class ExaminationManager : MonoBehaviour
    {
        private Transform m_examinationPlace;
        private void Start()
        {
            m_examinationPlace = GameObject.FindGameObjectWithTag("Examining_Point").transform;
            PlayerExaminationData.Instance.ExaminingPlace = m_examinationPlace;
        }
        private void Update()
        {
            if (PlayerExamination_InputData.Instance.ExaminationButtonisHolding && PlayerExaminationData.Instance.CurrentExaminationObject != null)
            {
                PlayerExaminationData.Instance.Examine();
            }
            else if (PlayerExamination_InputData.Instance.ExaminationButtonReleased && PlayerExaminationData.Instance.CurrentExaminationObject != null)
            {
                PlayerExaminationData.Instance.UnExamine();
            }
        }

        private void OnDisable()
        {
            PlayerExaminationData.Instance.ResetData();
        }
    }
}
