using UnityEngine;
using System.Collections;
using LevelManagement.Utilities;
namespace LevelManagement.Missions
{
    public class MissionSelector : Selector<MissionList, MissionSpecs>
    {
        protected override void ClampIndex()
        {
            if (_list.TotalMissions == 0)
            {
                Debug.LogWarning("MISSION SELECTOR ClampIndex: missing mission setup!");
                return;
            }

            if (_currentIndex >= _list.TotalMissions)
            {
                _currentIndex = 0;
            }

            if (_currentIndex < 0)
            {
                _currentIndex = _list.TotalMissions - 1;
            }
            if(CurrentIndex == 1)
            {
                StartCoroutine(WaitForSomeTime());
            }
        }

        public override MissionSpecs GetCurrentItem()
        {
            return _list.GetMission(CurrentIndex);
        }

        public override MissionSpecs GetItem(int index)
        {
            return _list.GetMission(index);
        }

        IEnumerator WaitForSomeTime()
        {
            yield return new WaitForSeconds(0.5f);
            if (!UserLearningSystem.Instance.Learn.learnItems[12].value)
            {
                UserLearningSystem.Instance.tipRequested = true;
                UserLearningSystem.Instance.currentTipIndex = 12;
            }
        }
    }
}