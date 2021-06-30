using Project.Scripts.GameStates.Interfaces;
using Project.Scripts.Scenes.Abstract;

namespace Project.Scripts.GameStates.Abstract
{
    public abstract class GameState
    {
        protected readonly Scene _scene;
        protected readonly IStateSwitcher _stateSwitcher;

        protected GameState(Scene scene, IStateSwitcher stateSwitcher)
        {
            _scene = scene;
            _stateSwitcher = stateSwitcher;
        }
        
        public abstract void Enter();
        public abstract void Exit();
    }
}