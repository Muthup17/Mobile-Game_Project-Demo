﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace LevelManagement.Missions
{
    [Serializable]
    public class MissionSpecs
    {
        #region INSPECTOR
        [SerializeField] protected string _name;
        [SerializeField] [Multiline] protected string _description;
        [SerializeField] protected string _sceneName;
        [SerializeField] protected string _id;
        [SerializeField] protected Sprite _image;
        [SerializeField] private int numberOfPowerUps;
        [SerializeField] PowerUp[] powers;
        #endregion

        #region PROPERTIES
        public string Name => _name;
        public string Description => _description;
        public string SceneName => _sceneName;
        public string Id => _id;
        public Sprite Image => _image;
        public int NumberOfPowerUps => powers.Length;
        public PowerUp GetPower(int i)
        {
            return powers[i];
        }
        #endregion


    }
}