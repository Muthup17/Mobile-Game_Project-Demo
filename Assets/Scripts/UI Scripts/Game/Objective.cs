﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SampleGame
{  
    public class Objective : MonoBehaviour
    {
        // tag to identify the player
        [SerializeField]
        private string _playerTag = "Player";

        // is the objective complete?
        private bool _isComplete;
        public bool IsComplete { get { return _isComplete; } }

        // set the objective to complete
        public void CompleteObjective()
        {
            _isComplete = true;
        }

        // when the player touches the trigger...
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_playerTag))
            {
                CompleteObjective();
            }
        }

    }
}
