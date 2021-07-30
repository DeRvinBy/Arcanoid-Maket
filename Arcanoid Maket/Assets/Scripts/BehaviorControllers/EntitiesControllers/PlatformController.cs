using Animations;
using BehaviorControllers.Abstract;
using EventInterfaces.BallEvents;
using EventInterfaces.GameEvents;
using EventInterfaces.StatesEvents;
using GameComponents.Platform.Behaviour;
using GameSettings.GamePlatformSettings;
using MyLibrary.CollisionStorage.Colliders2D;
using MyLibrary.EventSystem;
using UnityEngine;

namespace BehaviorControllers.EntitiesControllers
{
    public class PlatformController : EntityController, IPrepareGameplayHandler, IStartGameplayHandler, IEndGameplayHandler, IContinueGameHandler
    {
        [SerializeField]
        private PlatformSettings _settings;

        [SerializeField]
        private PlatformBehaviour _behaviour;

        [SerializeField]
        private GeneralCollider2D _collider;
        
        [SerializeField]
        private Transform _spawnPlatformTransform;

        private float _previousPlatformSize;
        private ValueAnimation _valueAnimation;
        
        private void OnEnable()
        {
            EventBus.Subscribe(this);
            _collider.RegisterCollider(this);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
            _collider.UnregisterCollider(this);
        }

        public override void Initialize()
        {
            _behaviour.Initialize();
            _valueAnimation = new ValueAnimation(_settings.ValueConfig.EaseMode, _settings.ValueConfig.Duration);
        }

        public void SetAdditionalSpeed(float value)
        {
            _behaviour.UpdatePlatformSpeed(_settings.BaseSpeed + value);
        }
        
        public void SetAdditionalSize(float value)
        {
            var targetSize = _settings.BaseSize + value;
            _valueAnimation.PlayAnimation(_previousPlatformSize, targetSize, _behaviour.UpdatePlatformSize);
            _previousPlatformSize = targetSize;
        }
        
        public void OnPrepareGame()
        {
            _valueAnimation.StopAnimation();
            _behaviour.SetupPlatform(_settings.BaseSpeed, _settings.BaseSize);
            _previousPlatformSize = _settings.BaseSize;
        }

        public void OnStartGame()
        {
            SpawnBall();
        }

        private void SpawnBall()
        {
            EventBus.RaiseEvent<IBallSceneHandler>(a => a.OnSpawnBallAtPlatform(_spawnPlatformTransform));
        }

        public void OnContinueGame()
        {
            _behaviour.ResetPlatformWithCallback(SpawnBall);
        }

        public void OnEndGame()
        {
            _behaviour.ResetPlatform();
            _valueAnimation.StopAnimation();
        }
    }
}