﻿using Project.Scripts.BehaviorControllers.Abstract;
using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.UI.Popups;
using Project.Scripts.Utils.EventSystem;
using Project.Scripts.Utils.UI.Popup;

namespace Project.Scripts.BehaviorControllers.GameSceneControllers
{
    public class UIController : GameController, IEndGameHandler
    {
        private PopupsController _popupsController;

        public override void Initialize(ControllersManager controllersManager)
        {
            _popupsController = controllersManager.GetEntityController<PopupsController>();

            EventBus.Subscribe(this);
        }

        public void OnWinGame()
        {
            StartCoroutine(_popupsController.ShowPopup<WinPopup>());
        }

        public void OnLoseGame()
        {
            StartCoroutine(_popupsController.ShowPopup<LosePopup>());
        }
    }
}