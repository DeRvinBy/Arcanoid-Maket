using GameEntities.Bonuses.Enumerations;
using UnityEngine;

namespace GameSettings.GameBonusSettings.BonusesSettings
{
    public class BallVelocityBonusSettings : MonoBehaviour
    {
        [SerializeField]
        [Min(0f)]
        private float _variableVelocity = 2;

        [SerializeField]
        [Min(0f)]
        private float _timeOfEffect = 5;
        
        [SerializeField]
        [Range(0, 10f)]
        private float _maxBallVelocity = 2;
        
        [SerializeField]
        [Range(-10f, 0f)]
        private float _minBallVelocity = -2;
        
        public float TimeOfEffect => _timeOfEffect;
        
        public float GetLimitVelocity(ValueModifer modifer, float currentVariableVelocity)
        {
            var result = _variableVelocity * (int)modifer;
            if (currentVariableVelocity + result > _maxBallVelocity)
            {
                result = _maxBallVelocity - currentVariableVelocity;
            }
            else if (currentVariableVelocity + result < _minBallVelocity)
            {
                result = _minBallVelocity - currentVariableVelocity;
            }

            return result;
        }
    }
}