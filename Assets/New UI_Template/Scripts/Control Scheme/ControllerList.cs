using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement.Controller
{
    [CreateAssetMenu(fileName = "ControllerList", menuName = "Selectors/Controllers/Create ControllerList", order = 1)]
    public class ControllerList : ScriptableObject
    {
        [SerializeField] private List<string> _controllers;
        public int ControllerCount => _controllers.Count;

        public string GetController(int index)
        {
            return _controllers[index];
        }
    }
}