using Project.Scripts.BehaviorControllers.Abstract;
using Project.Scripts.EventInterfaces.PacksEvents;
using Project.Scripts.GameEntities;
using Project.Scripts.UI.Popups;
using Project.Scripts.Utils.EventSystem;
using Project.Scripts.Utils.UI.Popup;
using UnityEngine;

namespace Project.Scripts.BehaviorControllers.GameControllers
{
    public class MenuController : GameController, IPackButtonPressedHandler
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