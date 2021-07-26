using GameEntities.Bonuses.Enumerations;
using UnityEngine;

namespace GameSettings.GameBonusSettings.BonusesSettings
{
    public class VariableValueBonusSettings : MonoBehaviour
    {
        [SerializeField]
        [Min(0f)]
        private float _variableValue = 2;

        [SerializeField]
        [Min(0f)]
        private float _timeOfEffect = 5;
        
        [SerializeField]
        [Range(0, 10f)]
        private float _maxValue = 2;
        
        [SerializeField]
        [Range(-10f, 0f)]
        private float _minValue = -2;
        
        public float TimeOfEffect => _timeOfEffect;
        
        public float GetLimitValue(ValueModifer modifer, float currentValue)
        {
            var result = _variableValue * (int)modifer;
            if (currentValue + result > _maxValue)
            {
                result = _maxValue - currentValue;
            }
            else if (currentValue + result < _minValue)
            {
                result = _minValue - currentValue;
            }

            return result;
        }
    }
}