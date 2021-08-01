using System.Collections;
using BehaviorControllers.Abstract;
using BehaviorControllers.EntitiesControllers;
using EventInterfaces.PacksEvents;
using EventInterfaces.StatesEvents;
using GamePacks;
using MyLibrary.EventSystem;
using MyLibrary.UI.Popup;
using MyLibrary.UI.Transition;
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

        private void Awake()
        {
            StartCoroutine(ShowMenu());
        }

        private IEnumerator ShowMenu()
        {
            yield return TransitionController.Instance.ShowForwardTransition();
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
            var isSaveExist = PacksManager.Instance.IsSaveExistOnStart();
            if (isSaveExist)
            {
                EventBus.RaiseEvent<IPacksChoosingHandler>(a => a.OnStartChoosePack());
            }
            else
            {
                PacksManager.Instance.SetupFirstPack();
                EventBus.RaiseEvent<IPackChangedHandler>(a => a.OnPackChanged());
                StartCoroutine(StartGameScene());
            }
        }

        public void OnPackButtonPressed()
        {
            StartCoroutine(StartGameScene());
        }

        private IEnumerator StartGameScene()
        {
            yield return TransitionController.Instance.ShowBackwardTransition();
            PopupsController.Instance.ClearPopups();
            _scenesController.LoadScene(_gameSceneID);
        }
    }
}