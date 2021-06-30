using Project.Scripts.GameStates.Interfaces;

namespace Project.Scripts.GameStates.Abstract
{
    public abstract class GameState
    {
        protected readonly IStateSwitcher _stateSwitcher;

        protected GameState(IStateSwitcher stateSwitcher)
        {
            _stateSwitcher = stateSwitcher;
        }
        
        public abstract void Enter();
        public abstract void Exit();
    }
}