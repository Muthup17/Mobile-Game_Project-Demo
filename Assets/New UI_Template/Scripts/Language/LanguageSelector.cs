using LevelManagement.Utilities;
using UnityEngine;

namespace LevelManagement.Language
{
    public class LanguageSelector : Selector<LanguageList, string>
    {
        protected override void ClampIndex()
        {
            if (_list.LanguageCount == 0)
            {
                Debug.LogWarning("MISSION SELECTOR ClampIndex: missing mission setup!");
                return;
            }

            if (_currentIndex >= _list.LanguageCount)
            {
                _currentIndex = 0;
            }

            if (_currentIndex < 0)
            {
                _currentIndex = _list.LanguageCount - 1;
            }
        }

        public override string GetCurrentItem()
        {
            return _list.GetLanguage(CurrentIndex);
        }

        public override string GetItem(int index)
        {
            return _list.GetLanguage(index);
        }
    }
}