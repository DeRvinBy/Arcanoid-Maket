using BehaviorControllers.EntitiesControllers;
using EventInterfaces.BonusEvents.Ball;
using EventInterfaces.StatesEvents;
using GameComponents.Bonus.Effects;
using GameEntities.Bonuses.Enumerations;
using MyLibrary.EventSystem;
using UnityEngine;

namespace GameComponents.Bonus.BonusesManagers.Ball
{
    public class BallsVelocityBonusManager : MonoBehaviour, IBallVelocityBonusHandler, IPrepareGameplayHandler
    {
        [SerializeField]
        private BallsVelocityController _velocityController;

        [SerializeField]
        private VariableValueEffect _bonusEffect;

        private void OnEnable()
        {
            EventBus.Subscribe(this);
            _bonusEffect.OnValueChanged += UpdateBallsVelocity;
        }

        private void OnDisable()
        {
            EventBus.Subscribe(this);
            _bonusEffect.OnValueChanged -= UpdateBallsVelocity;
        }

        public void OnActivateVelocityBonus(ValueModifer modifer)
        {
            _bonusEffect.ActivateEffect(modifer);
        }

        private void UpdateBallsVelocity(float value)
        {
            _velocityController.SetAdditionalVelocity(value);
        }

        public void OnPrepareGame()
        {
            _bonusEffect.StopEffect();
        }
    }
}