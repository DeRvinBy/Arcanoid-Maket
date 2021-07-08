using Project.Scripts.Architecture.Abstract;
using Project.Scripts.Architecture.Interfaces;
using Project.Scripts.Architecture.Scenes;
using Project.Scripts.UI.PopupUI;

namespace Project.Scripts.GameStates.States
{
    public class LoseGameState : GameState
    {
        private Scene _scene;
        private PopupsController _popupsController;
        
        public LoseGameState(Scene scene, IStateSwitcher stateSwitcher) : base(stateSwitcher)
        {
            _scene = scene;
            _popupsController = scene.GetController<PopupsController>();
        }

        public override void Enter()
        {
            var routine = _popupsController.ShowPopup<LosePopup>();
            _scene.StartCoroutine(routine);
        }

        public override void Exit()
        {
            
        }
    }
}