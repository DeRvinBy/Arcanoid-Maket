using Library.EventSystem;

namespace EventInterfaces.Input
{
    public interface IInputEnabledHandler : IGlobalSubscriber
    {
        void OnEnableInput();
        void OnDisableInput();
    }
}