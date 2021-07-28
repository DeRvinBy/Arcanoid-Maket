using System.Collections;
using BehaviorControllers.Abstract;
using EventInterfaces.GameEvents;
using EventInterfaces.Input;
using EventInterfaces.PacksEvents;
using EventInterfaces.StatesEvents;
using GameComponents.Energy.Commands;
using GameComponents.Energy.Enumerations;
using MyLibrary.EnergySystem;
using MyLibrary.EventSystem;
using MyLibrary.UI.Popup;
using MyLibrary.UI.Transition;

namespace BehaviorControllers.GameControllers
{
    public class GameplayController : GameController, IStartGameHandler, IPackButtonPressedHandler, IEndGameHandler
    {
        private SpendEnergyCommand _spendEnergyStartGame;
        private SpendEnergyCommand _spendEnergyRestartGame;
        
        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void Start()
        {
            _spendEnergyStartGame = new SpendEnergyCommand();
            _spendEnergyRestartGame = new SpendEnergyCommand();
            EnergyManager.Instance.SetupCommandWithEnergy(_spendEnergyStartGame, (int)TypeActionForEnergy.StartLevel);
            EnergyManager.Instance.SetupCommandWithEnergy(_spendEnergyRestartGame, (int)TypeActionForEnergy.RestartLevel);
            StartCoroutine(StartGameScene());
        }

        private IEnumerator StartGameScene()
        {
            _spendEnergyStartGame.Execute();
            EventBus.RaiseEvent<IClearGameSceneHandler>(a => a.OnClearObjects());
            EventBus.RaiseEvent<IPrepareGameplayHandler>(a => a.OnPrepareGame());
            EventBus.RaiseEvent<IStartGameplayHandler>(a => a.OnStartGame());
            yield return TransitionController.Instance.ShowForwardTransition();
            EventBus.RaiseEvent<IInputEnabledHandler>(a => a.OnEnableInput());
        }
        
        private void StartGame()
        {
            StartCoroutine(PrepareAndStartGame());
        }

        private IEnumerator PrepareAndStartGame()
        {
            EventBus.RaiseEvent<IClearGameSceneHandler>(a => a.OnClearObjects());
            EventBus.RaiseEvent<IPrepareGameplayHandler>(a => a.OnPrepareGame());
            yield return PopupsController.Instance.HideAllActivePopups();
            EventBus.RaiseEvent<IStartGameplayHandler>(a => a.OnStartGame());
            EventBus.RaiseEvent<IInputEnabledHandler>(a => a.OnEnableInput());
        }
        
        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }

        public void OnStartGameProcess()
        {
            _spendEnergyStartGame.Execute();
            StartGame();
        }
        
        public void OnRestartGameProcess()
        {
            _spendEnergyRestartGame.Execute();
            StartGame();
        }

        public void OnPackButtonPressed()
        {
            _spendEnergyStartGame.Execute();
            StartGame();
        }

        public void OnWinGame()
        {
            EndGame();
        }

        public void OnLoseGame()
        {
            EndGame();
        }

        private void EndGame()
        {
            EventBus.RaiseEvent<IEndGameplayHandler>(a => a.OnEndGame());
            EventBus.RaiseEvent<IInputEnabledHandler>(a => a.OnDisableInput());
        }
    }
}