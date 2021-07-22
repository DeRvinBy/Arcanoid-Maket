using System.Collections;
using BehaviorControllers.Abstract;
using EventInterfaces.Input;
using EventInterfaces.PacksEvents;
using EventInterfaces.StatesEvents;
using MyLibrary.EventSystem;
using MyLibrary.UI.Popup;
using UI.Popups;
using UnityEngine;

namespace BehaviorControllers.GameControllers
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
        
        public void OnStartTime()
        {
            Time.timeScale = 1;
        }

        public void OnPause()
        {
            Time.timeScale = 0;
            EventBus.RaiseEvent<IInputEnabledHandler>(a => a.OnDisableInput());
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
            EventBus.RaiseEvent<IInputEnabledHandler>(a => a.OnEnableInput());
            Time.timeScale = 1;
        }
    }
}