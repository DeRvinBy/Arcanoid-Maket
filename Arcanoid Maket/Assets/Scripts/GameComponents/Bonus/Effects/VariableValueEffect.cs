using System;
using System.Collections;
using EventInterfaces.StatesEvents;
using GameEntities.Bonuses.Enumerations;
using GameSettings.GameBonusSettings.BonusesSettings;
using UnityEngine;

namespace GameComponents.Bonus.Effects
{
    public class VariableValueEffect : MonoBehaviour
    {
        public event Action<float> OnValueChanged;
        
        [SerializeField]
        private VariableValueBonusSettings _settings;

        private float _currentVariableValue;

        public void ActivateEffect(ValueModifer modifer)
        {
            var value = _settings.GetLimitValue(modifer, _currentVariableValue);
            StartCoroutine(StartEffect(value));
        }
        
        private IEnumerator StartEffect(float velocity)
        {
            _currentVariableValue += velocity;
            OnValueChanged?.Invoke(_currentVariableValue);
            yield return new WaitForSeconds(_settings.TimeOfEffect);
            _currentVariableValue -= velocity;
            OnValueChanged?.Invoke(_currentVariableValue);
        }

        public void StopEffect()
        {
            StopAllCoroutines();
            _currentVariableValue = 0;
            OnValueChanged?.Invoke(_currentVariableValue);
        }
    }
}