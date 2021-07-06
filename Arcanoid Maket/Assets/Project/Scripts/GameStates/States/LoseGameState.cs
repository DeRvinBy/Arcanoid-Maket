using Project.Scripts.GameStates.Abstract;
using Project.Scripts.GameStates.Interfaces;
using Project.Scripts.Scenes;
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