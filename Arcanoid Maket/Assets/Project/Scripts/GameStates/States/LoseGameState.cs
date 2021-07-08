using Project.Scripts.Architecture.Abstract;
using Project.Scripts.Architecture.Interfaces;
using Project.Scripts.Architecture.Scenes;
using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.UI.PopupUI;
using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.GameStates.States
{
    public class LoseGameState : GameState, IStartGameProccesHandler
    {
        private Scene _scene;
        private PopupsController _popupsController;
        
        public LoseGameState(Scene scene, IStateSwitcher stateSwitcher) : base(stateSwitcher)
        {
            _scene = scene;
            _popupsController = scene.GetController<PopupsController>();
            
            EventBus.Subscribe(this);
        }

        public override void Enter()
        {
            var routine = _popupsController.ShowPopup<LosePopup>();
            _scene.StartCoroutine(routine);
            
            _popupsController.StartPopup<LosePopup>();
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