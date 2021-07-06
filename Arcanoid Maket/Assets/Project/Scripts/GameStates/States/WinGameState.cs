using Project.Scripts.Architecture.Abstract;
using Project.Scripts.Architecture.Interfaces;
using Project.Scripts.Architecture.Scenes;
using Project.Scripts.UI.PopupUI;

namespace Project.Scripts.GameStates.States
{
    public class WinGameState : GameState
    {
        private PopupsController _popupsController;
        
        public WinGameState(Scene scene, IStateSwitcher stateSwitcher) : base(stateSwitcher)
        {
            _popupsController = scene.GetController<PopupsController>();
        }

        public override void Enter()
        {
            _popupsController.ShowPopup<WinPopup>();
        }

        public override void Exit()
        {
            
        }
    }
}