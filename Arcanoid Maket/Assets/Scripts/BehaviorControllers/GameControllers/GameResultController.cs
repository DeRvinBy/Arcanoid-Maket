using System.Collections;
using BehaviorControllers.Abstract;
using EventInterfaces.GameEvents;
using GamePacks;
using MyLibrary.EventSystem;
using MyLibrary.UI.Popup;
using UI.Popups;

namespace BehaviorControllers.GameControllers
{
    public class GameResultController : GameController, IEndGameHandler
    {
        private PopupsController _popupsController;

        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }

        public override void Initialize(ControllersManager controllersManager)
        {
            _popupsController = controllersManager.GetEntityController<PopupsController>();
        }

        public void OnWinGame()
        {
            StartCoroutine(WinGame());
        }

        private IEnumerator WinGame()
        {
            PacksManager.Instance.CompleteLevel();
            yield return _popupsController.ShowPopup<WinPopup>();
        }

        public void OnLoseGame()
        {
            StartCoroutine(_popupsController.ShowPopup<LosePopup>());
        }
    }
}