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
        
        private PopupsController _popupsController;
        private ScenesController _scenesController;

        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void Start()
        {
            StartCoroutine(_popupsController.ShowPopup<MenuPopup>());
        }
        
        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }
        
        public override void Initialize(ControllersManager controllersManager)
        {
            _popupsController = controllersManager.GetEntityController<PopupsController>();
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
                StartGameScene();
            }
        }
        
        public void OnPackButtonPressed()
        {
            StartGameScene();
        }

        private void StartGameScene()
        {
            _popupsController.ClearPopups();
            _scenesController.LoadScene(_gameSceneID);
        }
    }
}