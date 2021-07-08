using Project.Scripts.Architecture.Abstract;

namespace Project.Scripts.Architecture.Interfaces
{
    public interface IStateSwitcher
    {
        void SwitchState<T>() where T : GameState;
    }
}