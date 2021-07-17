using System.Collections;
using Project.Scripts.BehaviorControllers.Abstract;
using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.EventInterfaces.PacksEvents;
using Project.Scripts.EventInterfaces.StatesEvents;
using Project.Scripts.Packs;
using Project.Scripts.Utils.EventSystem;
using Project.Scripts.Utils.UI.Popup;

namespace Project.Scripts.BehaviorControllers.GameSceneControllers
{
    public class GameplayController : GameController, IStartGameHandler, IEndGameHandler, IPackButtonPressedHandler
    {
        private PopupsController _popupsController;
        
        public override void Initialize(ControllersManager controllersManager)
        {
            _popupsController = controllersManager.GetEntityController<PopupsController>();
            
            EventBus.Subscribe(this);
        }
        
        public void OnStartGameProcess()
        {
            StartGame();
        }
        
        public void OnPackButtonPressed()
        {
            StartGame();
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
        }
    }
}