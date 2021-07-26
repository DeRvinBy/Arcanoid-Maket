using BehaviorControllers.EntitiesControllers.EntitiesManagers;
using EventInterfaces.BonusEvents.Ball;
using MyLibrary.EventSystem;
using UnityEngine;

namespace GameComponents.Bonus.BonusesManagers.Ball
{
    public class ExtraBallBonusManager : MonoBehaviour, IExtraBallBonusHandler
    {
        [SerializeField]
        private BallsManager _manager;

        private readonly Vector2 _ballDirection = Vector2.down; 
        
        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Subscribe(this);
        }

        public void OnSpawnExtraBall(Vector2 spawnPosition)
        {
            _manager.SpawnBallInDirection(spawnPosition, _ballDirection);
        }
    }
}