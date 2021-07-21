using System.Collections;
using BehaviorControllers.EntitiesControllers.EntitiesManagers;
using EventInterfaces.BonusEvents;
using GameEntities.Bonuses.Enumerations;
using GameSettings.GameBonusSettings.BonusesSettings;
using MyLibrary.EventSystem;
using UnityEngine;

namespace GameComponents.Bonus.BonusManagers
{
    public class BallsVelocityBonusManager : MonoBehaviour, IBallBonusHandler
    {
        [SerializeField]
        private BallsManager _manager;
        
        [SerializeField]
        private BallVelocityBonusSettings _settings;
        
        private float _currentVariableVelocity;

        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Subscribe(this);
        }

        public void ActivateVelocityBonus(ValueModifer modifer)
        {
            var velocity = _settings.GetLimitVelocity(modifer, _currentVariableVelocity);
            StartCoroutine(ChangeSpeed(velocity));
        }

        private IEnumerator ChangeSpeed(float velocity)
        {
            _currentVariableVelocity += velocity;
            UpdateBallsSpeed();
            yield return new WaitForSeconds(_settings.TimeOfEffect);
            _currentVariableVelocity -= velocity;
            UpdateBallsSpeed();
        }

        private void UpdateBallsSpeed()
        {
            _manager.InvokeBallsAction(a => a.SetAdditionalVelocity(_currentVariableVelocity));
        }
    }
}