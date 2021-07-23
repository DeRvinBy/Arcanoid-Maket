using BehaviorControllers.EntitiesControllers.EntitiesManagers;
using EventInterfaces.BallEvents;
using EventInterfaces.BonusEvents;
using GameComponents.Bonus.Abstract;
using GameComponents.Bonus.Effects;
using GameEntities.Ball;
using GameEntities.Bonuses.Enumerations;
using MyLibrary.EventSystem;
using UnityEngine;

namespace GameComponents.Bonus.BonusesManagers
{
    public class BallsVelocityBonusManager : AbstractBonusManager, IBallVelocityBonusHandler, IBallsManagerHandler
    {
        [SerializeField]
        private BallsManager _manager;

        [SerializeField]
        private VariableValueEffect _bonusEffect;
        
        private float _currentVariableVelocity;

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

        public void OnSpawnNewBall(BallEntity ball)
        {
            ball.SetAdditionalVelocity(_currentVariableVelocity);
        }

        public void OnActivateVelocityBonus(ValueModifer modifer)
        {
            _bonusEffect.ActivateEffect(modifer);
        }

        private void UpdateBallsVelocity(float value)
        {
            _currentVariableVelocity = value;
            _manager.InvokeBallsAction(a => a.SetAdditionalVelocity(value));
        }

        public override void OnPrepareGame()
        {
            _currentVariableVelocity = 0;
            _bonusEffect.StopEffect();
        }
    }
}