using Project.Scripts.GameStates.Abstract;
using Project.Scripts.GameStates.Interfaces;
using Project.Scripts.GameStates.States.EventInterfaces;
using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.GameStates.States
{
    public class MainGameState : GameState, IEndGameHandler
    {
        public MainGameState(IStateSwitcher stateSwitcher) : base(stateSwitcher)
        {
            EventBus.Subscribe(this);
        }

        public override void Enter()
        {
            EventBus.RaiseEvent<IMainGameStateEvent>(a => a.StartGame());
        }

        public override void Exit()
        {
            
        }

        public void WinGame()
        {
            _stateSwitcher.SwitchState<WinGameState>();
        }

        public void EndGame()
        {
            _stateSwitcher.SwitchState<LoseGameState>();
        }
    }
}