using Project.Scripts.GameStates.Abstract;

namespace Project.Scripts.GameStates.Interfaces
{
    public interface IStateSwitcher
    {
        void SwitchState<T>() where T : GameState;
    }
}