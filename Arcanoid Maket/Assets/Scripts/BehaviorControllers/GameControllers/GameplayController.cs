using System.Collections;
using BehaviorControllers.Abstract;
using EventInterfaces.GameEvents;
using EventInterfaces.Input;
using EventInterfaces.PacksEvents;
using EventInterfaces.StatesEvents;
using MyLibrary.EventSystem;
using MyLibrary.UI.Popup;

namespace BehaviorControllers.GameControllers
{
    public class GameplayController : GameController, IStartGameHandler, IPackButtonPressedHandler, IEndGameHandler
    {
        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void Start()
        {
            StartGame();
        }

        // private IEnumerator StartGameScene()
        // {
        //     EventBus.RaiseEvent<IClearGameSceneHandler>(a => a.OnClearObjects());
        //     EventBus.RaiseEvent<IPrepareGameplayHandler>(a => a.OnPrepareGame());
        //     EventBus.RaiseEvent<IStartGameplayHandler>(a => a.OnStartGame());
        //     //yield return _popupsController.ShowTransition<TransitionPopup>();
        //     EventBus.RaiseEvent<IInputEnabledHandler>(a => a.OnEnableInput());
        // }
        
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
            StartGame();
        }
        
        public void OnPackButtonPressed()
        {
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