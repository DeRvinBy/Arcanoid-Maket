using System;
using GameComponents.Energy.Enumerations;
using UnityEngine;

namespace GameComponents.Energy.Config
{
    [Serializable]
    public class GameEnergyValue
    {
        [SerializeField]
        private TypeActionForEnergy _typeAction;

        [SerializeField]
        private int _energyValue;

        public TypeActionForEnergy TypeAction => _typeAction;

        public int EnergyValue => _energyValue;
    }
}