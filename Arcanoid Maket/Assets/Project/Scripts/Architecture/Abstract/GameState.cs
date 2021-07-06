using Project.Scripts.Architecture.Interfaces;

namespace Project.Scripts.Architecture.Abstract
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