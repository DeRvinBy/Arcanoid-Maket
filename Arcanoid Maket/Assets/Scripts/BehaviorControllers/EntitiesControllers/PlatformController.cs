using BehaviorControllers.Abstract;
using EventInterfaces.BallEvents;
using EventInterfaces.GameEvents;
using EventInterfaces.StatesEvents;
using GameComponents.Platform.Behaviour;
using GameComponents.Platform.Data;
using GameSettings.GamePlatformSettings;
using Scripts.Utils.EventSystem;
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
        private Transform _spawnPlatformTransform;

        private PlatformProperties _properties;

        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }

        public override void Initialize()
        {
            _properties = new PlatformProperties();
            _behaviour.Initialize(_properties);
        }
        
        public void OnPrepareGame()
        {
            _properties.SetupProperties(_settings);
            _behaviour.SetupPlatform();
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
        }
    }
}