using System.Collections;
using Scripts.BehaviorControllers.Abstract;
using Scripts.EventInterfaces.PacksEvents;
using Scripts.EventInterfaces.StatesEvents;
using Scripts.UI.Popups;
using Scripts.Utils.EventSystem;
using Scripts.Utils.UI.Popup;
using UnityEngine;

namespace Scripts.BehaviorControllers.GameControllers
{
    public class PauseController : GameController, IPauseGameHandler, IPackButtonPressedHandler
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

        public void OnPause()
        {
            Time.timeScale = 0;
            StartCoroutine(_popupsController.ShowPopup<PausePopup>());
        }
        
        public void OnPackButtonPressed()
        {
            OnContinue();
        }

        public void OnContinue()
        {
            StartCoroutine(ContinueGame());
        }

        private IEnumerator ContinueGame()
        {
            yield return _popupsController.HideAllActivePopups();
            Time.timeScale = 1;
        }
    }
}