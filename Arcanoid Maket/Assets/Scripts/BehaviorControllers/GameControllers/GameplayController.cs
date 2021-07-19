using System.Collections;
using Scripts.BehaviorControllers.Abstract;
using Scripts.EventInterfaces.GameEvents;
using Scripts.EventInterfaces.Input;
using Scripts.EventInterfaces.PacksEvents;
using Scripts.EventInterfaces.StatesEvents;
using Scripts.GamePacks;
using Scripts.Utils.EventSystem;
using Scripts.Utils.UI.Popup;

namespace Scripts.BehaviorControllers.GameControllers
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
            EventBus.RaiseEvent<IPrepareGameplayHandler>(a => a.OnPrepareGame());
            PacksManager.Instance.PreparePack();
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