﻿using System.Collections;
using BehaviorControllers.Abstract;
using BehaviorControllers.EntitiesControllers;
using EventInterfaces.PacksEvents;
using EventInterfaces.StatesEvents;
using GamePacks;
using MyLibrary.EventSystem;
using MyLibrary.UI.Popup;
using UI.Popups;
using UnityEngine;

namespace BehaviorControllers.GameControllers
{
    public class MenuController : GameController, IPackButtonPressedHandler, IStartGameplayHandler
    {
        [SerializeField]
        private int _gameSceneID = 1;
        
        private ScenesController _scenesController;

        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void Start()
        {
            StartCoroutine(ShowMenu());
        }

        private IEnumerator ShowMenu()
        {
           // yield return PopupsController.Instance.ShowTransition<TransitionPopup>();
            yield return PopupsController.Instance.ShowPopup<MenuPopup>();
        }
        
        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }
        
        public override void Initialize(ControllersManager controllersManager)
        {
            _scenesController = controllersManager.GetEntityController<ScenesController>();
        }
        
        public void OnStartGame()
        {
            var isSaveExist = PacksManager.Instance.IsSaveExist();
            if (isSaveExist)
            {
                EventBus.RaiseEvent<IPacksChoosingHandler>(a => a.OnStartChoosePack());
            }
            else
            {
                OnPackButtonPressed();
            }
        }

        public void OnPackButtonPressed()
        {
            // StartCoroutine(StartGameScene());
            PopupsController.Instance.ClearPopups();
            _scenesController.LoadScene(_gameSceneID);
        }

        // private IEnumerator StartGameScene()
        // {
        //     yield return _popupsController.HideTransition<TransitionPopup>();
        //     
        // }
    }
}