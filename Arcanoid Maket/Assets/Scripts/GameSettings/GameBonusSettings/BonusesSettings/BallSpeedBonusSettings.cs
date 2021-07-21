using System;
using UnityEngine;

namespace GameSettings.GameBonusSettings.BonusesSettings
{
    [Serializable]
    public class BallSpeedBonusSettings
    {
        [SerializeField]
        private float _speedVariableValue;

        [SerializeField]
        private float _timeOfEffect;
        
        public float SpeedVariableValue => _speedVariableValue;
        public float TimeOfEffect => _timeOfEffect;
    }
}