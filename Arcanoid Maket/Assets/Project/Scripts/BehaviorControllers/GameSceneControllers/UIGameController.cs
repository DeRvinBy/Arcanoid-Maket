using System.Collections;
using Project.Scripts.BehaviorControllers.Abstract;
using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.Packs;
using Project.Scripts.UI.Popups;
using Project.Scripts.Utils.EventSystem;
using Project.Scripts.Utils.UI.Popup;

namespace Project.Scripts.BehaviorControllers.GameSceneControllers
{
    public class UIGameController : GameController, IEndGameHandler
    {
        private PopupsController _popupsController;
        private PacksController _packsController;

        public override void Initialize(ControllersManager controllersManager)
        {
            _popupsController = controllersManager.GetEntityController<PopupsController>();
            _packsController = controllersManager.GetEntityController<PacksController>();

            EventBus.Subscribe(this);
        }

        public void OnWinGame()
        {
            StartCoroutine(WinGame());
        }

        private IEnumerator WinGame()
        {
            yield return _popupsController.ShowPopup<WinPopup>();
            _packsController.CompleteLevel();
        }

        public void OnLoseGame()
        {
            StartCoroutine(_popupsController.ShowPopup<LosePopup>());
        }
    }
}