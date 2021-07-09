using System.Collections;
using Project.Scripts.BehaviorControllers.Abstract;
using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.EventInterfaces.StatesEvents;
using Project.Scripts.UI.PopupUI;
using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.BehaviorControllers.GameSceneControllers
{
    public class GameplayController : GameController, IEndGameHandler, IStartGameplayHandler
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
            EventBus.RaiseEvent<IPrepareStateHandler>(a => a.OnPrepareGame());
            yield return _popupsController.HideAllActivePopups();
            EventBus.RaiseEvent<IMainGameStateStartHandler>(a => a.OnStartGame());
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
            EventBus.RaiseEvent<IMainGameStateEndHandler>(a => a.OnEndGame());
        }
    }
}