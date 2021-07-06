using Project.Scripts.Architecture.Abstract;
using Project.Scripts.Architecture.Interfaces;
using Project.Scripts.Architecture.Scenes;
using Project.Scripts.UI.PopupUI;

namespace Project.Scripts.GameStates.States
{
    public class LoseGameState : GameState
    {
        private PopupsController _popupsController;
        
        public LoseGameState(Scene scene, IStateSwitcher stateSwitcher) : base(stateSwitcher)
        {
            _popupsController = scene.GetController<PopupsController>();
        }

        public override void Enter()
        {
            _popupsController.ShowPopup<LosePopup>();
        }

        public override void Exit()
        {
            
        }
    }
}