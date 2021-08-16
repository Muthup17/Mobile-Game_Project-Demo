using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LevelManagement.Utilities;
namespace LevelManagement.Controller
{
    public class ControllerSelector : Selector<ControllerList, string>
    {
        public override string GetCurrentItem()
        {
            return _list.GetController(CurrentIndex);
        }

        public override string GetItem(int index)
        {
            return _list.GetController(index);
        }

        protected override void ClampIndex()
        {
            if (_list.ControllerCount == 0)
            {
                Debug.LogWarning("MISSION SELECTOR ClampIndex: missing mission setup!");
                return;
            }

            if (_currentIndex >= _list.ControllerCount)
            {
                _currentIndex = 0;
            }

            if (_currentIndex < 0)
            {
                _currentIndex = _list.ControllerCount - 1;
            }
        }
    }
}