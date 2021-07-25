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
        private PopupsController _popupsController;

        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void Start()
        {
            StartGame();
        }
        
        private void StartGame()
        {
            StartCoroutine(PrepareAndStartGame());
        }

        private IEnumerator PrepareAndStartGame()
        {
            EventBus.RaiseEvent<IClearGameSceneHandler>(a => a.OnClearObjects());
            EventBus.RaiseEvent<IPrepareGameplayHandler>(a => a.OnPrepareGame());
            yield return _popupsController.HideAllActivePopups();
            EventBus.RaiseEvent<IStartGameplayHandler>(a => a.OnStartGame());
            EventBus.RaiseEvent<IInputEnabledHandler>(a => a.OnEnableInput());
        }
        
        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }
        
        public override void Initialize(ControllersManager controllersManager)
        {
            _popupsController = controllersManager.GetEntityController<PopupsController>();
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