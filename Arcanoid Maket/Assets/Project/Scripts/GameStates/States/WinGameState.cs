using Project.Scripts.Architecture.Abstract;
using Project.Scripts.Architecture.Interfaces;
using Project.Scripts.Architecture.Scenes;
using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.UI.PopupUI;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.GameStates.States
{
    public class WinGameState : GameState, IStartGameProccesHandler
    {
        private Scene _scene;
        private PopupsController _popupsController;
        
        public WinGameState(Scene scene, IStateSwitcher stateSwitcher) : base(stateSwitcher)
        {
            _scene = scene;
            _popupsController = _scene.GetController<PopupsController>();
            
            EventBus.Subscribe(this);
        }

        public override void Enter()
        {
            var routine = _popupsController.ShowPopup<WinPopup>();
            _scene.StartCoroutine(routine);
            
            _popupsController.StartPopup<WinPopup>();
        }

        public override void Exit()
        {
            
        }

        public void OnStartGameProcess()
        {
            _stateSwitcher.SwitchState<PreparationState>();
        }
    }
}