using System.Collections;
using Project.Scripts.BehaviorControllers.Abstract;
using Project.Scripts.EventInterfaces.BallEvents;
using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.EventInterfaces.StatesEvents;
using Project.Scripts.GameEntities.Platform.Data;
using Project.Scripts.GameSettings.GamePlatformSettings;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.GameEntities.Platform
{
    public class PlatformEntity : EntityController, IStartGameplayHandler, IEndGameplayHandler, IContinueGameHandler
    {
        [SerializeField]
        private PlatformSettings _settings;

        [SerializeField]
        private PlatformBehaviour _behaviour;

        [SerializeField]
        private Transform _spawnPlatformTransform;

        private PlatformProperties _properties;
        
        public override void Initialize()
        {
            _properties = new PlatformProperties();
            _behaviour.Initialize(_properties);

            EventBus.Subscribe(this);
        }
        
        public void OnStartGame()
        {
            _properties.SetupProperties(_settings);
            _behaviour.SetupPlatform();
            SpawnBall();
        }

        private void SpawnBall()
        {
            EventBus.RaiseEvent<IBallSceneHandler>(a => 
                a.OnSpawnBallAtPosition(_spawnPlatformTransform.position, _spawnPlatformTransform));
        }

        public void OnContinueGame()
        {
            _behaviour.ResetPlatform(SpawnBall);
        }

        public void OnEndGame()
        {
            _behaviour.DisablePlatform();
        }
    }
}