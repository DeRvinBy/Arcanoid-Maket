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
        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }

        public void OnWinGame()
        {
            StartCoroutine(WinGame());
        }

        private IEnumerator WinGame()
        {
            PacksManager.Instance.CompleteLevel();
            yield return PopupsController.Instance.ShowPopup<WinPopup>();
        }

        public void OnLoseGame()
        {
            StartCoroutine(PopupsController.Instance.ShowPopup<LosePopup>());
        }
    }
}