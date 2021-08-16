using UnityEngine.UI;
using UnityEngine;
using LevelManagement.Language;

namespace LevelManagement
{
    public class LanguageSettings : MonoBehaviour
    {
        [SerializeField] Text languageText;
        LanguageSelector languageSelector;
        string currentLanguage;
        private void Awake()
        {
            languageSelector = GetComponent<LanguageSelector>();
            UpdateInfo();
        }

        public void UpdateInfo()
        {
            currentLanguage = languageSelector.GetCurrentItem();
            languageText.text = currentLanguage;
        }
        public void OnNextPressed()
        {
            languageSelector.IncrementIndex();
            UpdateInfo();
        }

        public void OnPreviousPressed()
        {
            languageSelector.DecrementIndex();
            UpdateInfo();
        }
    }
}