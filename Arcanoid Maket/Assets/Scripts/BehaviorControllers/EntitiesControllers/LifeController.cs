using BehaviorControllers.Abstract;
using EventInterfaces.GameEvents;
using EventInterfaces.StatesEvents;
using GameSettings.LifeSettings;
using MyLibrary.EventSystem;
using UI.Header.LifeUI;
using UnityEngine;

namespace BehaviorControllers.EntitiesControllers
{
    public class LifeController : EntityController, IPrepareGameplayHandler, IPlayerBallsHandler
    {
        [SerializeField]
        private LifeSettings _settings;

        [SerializeField]
        private LifeUI _lifeUI;

        private int _lifeCount;

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
            _lifeUI.CreateLifeContainers(_settings);
        }

        public void IncreaseLifeCount()
        {
            _lifeCount++;

            if (_lifeCount > _settings.StartLifeCount)
            {
                _lifeCount = _settings.StartLifeCount;
            }
            _lifeUI.UpdateLifeCount(_lifeCount);
        }
        
        public void DecreaseLifeCount()
        {
            _lifeCount--;
            _lifeUI.UpdateLifeCount(_lifeCount);
            
            if (_lifeCount <= 0)
            {
                EventBus.RaiseEvent<IEndGameHandler>(a => a.OnLoseGame());
            }
        }

        public void OnPrepareGame()
        {
            _lifeCount = _settings.StartLifeCount;
            _lifeUI.UpdateLifeCount(_lifeCount);
        }
        
        public void OnPlayerBallLose()
        {
            DecreaseLifeCount();
            
            if(_lifeCount > 0)
            {
                EventBus.RaiseEvent<IContinueGameHandler>(a => a.OnContinueGame());
            }
        }
    }
}