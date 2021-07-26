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
        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }

        public void OnStartTime()
        {
            Time.timeScale = 1;
        }

        public void OnPause()
        {
            Time.timeScale = 0;
            EventBus.RaiseEvent<IInputEnabledHandler>(a => a.OnDisableInput());
            StartCoroutine(PopupsController.Instance.ShowPopup<PausePopup>());
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
            yield return PopupsController.Instance.HideAllActivePopups();
            EventBus.RaiseEvent<IInputEnabledHandler>(a => a.OnEnableInput());
            Time.timeScale = 1;
        }
    }
}