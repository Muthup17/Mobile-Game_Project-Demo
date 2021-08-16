using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement.Language
{
    [CreateAssetMenu(fileName = "LanguageList", menuName = "Selectors/Languages/Create LanguageList", order = 1)]
    public class LanguageList : ScriptableObject
    {
        [SerializeField] private List<string> _languages;
        public int LanguageCount => _languages.Count;

        public string GetLanguage(int index)
        {
            return _languages[index];
        }
    }
}