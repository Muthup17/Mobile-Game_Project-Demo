using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyExploration.Examine
{
    public enum ExaminationType
    {
        JUSTLOOKTYPE,
        AUDIOTYPE,
        BOOKTYPE
    }
    public interface IExaminable
    {
        ExaminationType ExamineType { get; }

        Transform ExaminationPlace { get; }

        void OnExamine();

        void AfterExamined();
    }
}
