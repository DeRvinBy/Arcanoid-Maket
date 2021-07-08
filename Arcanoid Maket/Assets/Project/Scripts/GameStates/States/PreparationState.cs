using System.Collections;
using Project.Scripts.Architecture.Abstract;
using Project.Scripts.Architecture.Interfaces;
using Project.Scripts.Architecture.Scenes;
using Project.Scripts.EventInterfaces.StatesEvents;
using Project.Scripts.UI.PopupUI;
using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.GameStates.States
{
    public class PreparationState : GameState
    {
        private Scene _scene;
        private PopupsController _popupsController;
        public PreparationState(Scene scene, IStateSwitcher stateSwitcher) : base(stateSwitcher)
        {
            _scene = scene;
            _popupsController = scene.GetController<PopupsController>();
        }

        public override void Enter()
        {
            _scene.StartCoroutine(PrepareGame());
        }

        private IEnumerator PrepareGame()
        {
            yield return _popupsController.HideAllActivePopups();
            EventBus.RaiseEvent<IPrepareStateHandler>(a => a.OnPrepareGame());
            _stateSwitcher.SwitchState<MainGameState>();
        }

        public override void Exit()
        {
            
        }
    }
}