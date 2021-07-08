using Project.Scripts.Architecture.Abstract;
using Project.Scripts.Architecture.Interfaces;
using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.EventInterfaces.StatesEvents;
using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.GameStates.States
{
    public class MainGameState : GameState, IWinGameHandler, ILoseGameHandler
    {
        public MainGameState(IStateSwitcher stateSwitcher) : base(stateSwitcher)
        {
            EventBus.Subscribe(this);
        }

        public override void Enter()
        {
            EventBus.RaiseEvent<IMainGameStateStartHandler>(a => a.OnStartGame());
        }

        public override void Exit()
        {
            
        }

        public void OnWinGame()
        {
            _stateSwitcher.SwitchState<WinGameState>();
        }

        public void OnLoseGame()
        {
            _stateSwitcher.SwitchState<LoseGameState>();
        }
    }
}