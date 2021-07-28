using BehaviorControllers.Abstract;
using EventInterfaces.GameEvents;
using EventInterfaces.StatesEvents;
using GameSettings.LifeSettings;
using MyLibrary.EventSystem;
using UI.Header.LifeUI;
using UnityEngine;

namespace BehaviorControllers.EntitiesControllers
{
    public class PlayerBallsController : EntityController, IPrepareGameplayHandler, IPlayerBallsHandler
    {
        [SerializeField]
        private PlayerBallsSettings _settings;

        [SerializeField]
        private PlayerBallsUI _playerBallsUI;

        private int _ballsCount;

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
            _playerBallsUI.CreatePlayerBallImageContainers(_settings);
        }

        public void IncreasePlayerBallCount()
        {
            _ballsCount++;

            if (_ballsCount > _settings.StartBallsCount)
            {
                _ballsCount = _settings.StartBallsCount;
            }
            _playerBallsUI.UpdatePlayerBallCount(_ballsCount);
        }
        
        public void DecreasePlayerBallCount()
        {
            _ballsCount--;
            _playerBallsUI.UpdatePlayerBallCount(_ballsCount);
        }

        public void OnPrepareGame()
        {
            _ballsCount = _settings.StartBallsCount;
            _playerBallsUI.UpdatePlayerBallCount(_ballsCount);
        }
        
        public void OnPlayerBallLose()
        {
            DecreasePlayerBallCount();

            if (_ballsCount < 0)
            {
                EventBus.RaiseEvent<IEndGameHandler>(a => a.OnLoseGame());
            }
            else
            {
                EventBus.RaiseEvent<IContinueGameHandler>(a => a.OnContinueGame());
            }
        }
    }
}