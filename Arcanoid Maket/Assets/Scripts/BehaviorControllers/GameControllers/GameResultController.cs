using System.Collections;
using Scripts.BehaviorControllers.Abstract;
using Scripts.EventInterfaces.GameEvents;
using Scripts.GamePacks;
using Scripts.UI.Popups;
using Scripts.Utils.EventSystem;
using Scripts.Utils.UI.Popup;

namespace Scripts.BehaviorControllers.GameControllers
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
            yield return _popupsController.ShowPopup<WinPopup>();
            PacksManager.Instance.CompleteLevel();
        }

        public void OnLoseGame()
        {
            StartCoroutine(_popupsController.ShowPopup<LosePopup>());
        }
    }
}