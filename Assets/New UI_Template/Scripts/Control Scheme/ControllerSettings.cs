using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using LevelManagement.Controller;

namespace LevelManagement
{
    public class ControllerSettings : MonoBehaviour
    {
        [SerializeField] Text controllerText;
        ControllerSelector controllerSelector;
        string currentController;
        private void Awake()
        {
            controllerSelector = GetComponent<ControllerSelector>();
            UpdateInfo();
        }

        public void UpdateInfo()
        {
            currentController = controllerSelector.GetCurrentItem();
            controllerText.text = currentController;
        }
        public void OnNextPressed()
        {
            controllerSelector.IncrementIndex();
            UpdateInfo();
        }

        public void OnPreviousPressed()
        {
            controllerSelector.DecrementIndex();
            UpdateInfo();
        }
    }
}