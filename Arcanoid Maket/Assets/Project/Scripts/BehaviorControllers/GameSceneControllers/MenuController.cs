using System;
using Project.Scripts.BehaviorControllers.Abstract;
using Project.Scripts.EventInterfaces.PacksEvents;
using Project.Scripts.GameEntities;
using Project.Scripts.UI.Popups;
using Project.Scripts.Utils.EventSystem;
using Project.Scripts.Utils.UI.Popup;
using UnityEngine;

namespace Project.Scripts.BehaviorControllers.GameSceneControllers
{
    public class MenuController : GameController, IPackButtonPressedHandler
    {
        [SerializeField]
        private int _gameSceneID = 1;
        
        private PopupsController _popupsController;
        private ScenesController _scenesController;
        
        public override void Initialize(ControllersManager controllersManager)
        {
            base.Initialize(controllersManager);
            _popupsController = controllersManager.GetEntityController<PopupsController>();
            _scenesController = controllersManager.GetEntityController<ScenesController>();
            
            EventBus.Subscribe(this);
        }

        private void OnDestroy()
        {
            EventBus.Unsubscribe(this);
        }

        private void Start()
        {
            StartCoroutine(_popupsController.ShowPopup<MenuPopup>());
        }

        public void OnPackButtonPressed()
        {
            _popupsController.ClearPopups();
            _scenesController.LoadScene(_gameSceneID);
        }
    }
}