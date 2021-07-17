using System.Collections;
using Project.Scripts.BehaviorControllers.Abstract;
using Project.Scripts.EventInterfaces.PacksEvents;
using Project.Scripts.EventInterfaces.StatesEvents;
using Project.Scripts.UI.Popups;
using Project.Scripts.Utils.EventSystem;
using Project.Scripts.Utils.UI.Popup;
using UnityEngine;

namespace Project.Scripts.BehaviorControllers.GameControllers
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