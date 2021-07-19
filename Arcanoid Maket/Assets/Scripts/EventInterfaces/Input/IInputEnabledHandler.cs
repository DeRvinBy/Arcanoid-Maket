using Scripts.Utils.EventSystem;

namespace Scripts.EventInterfaces.Input
{
    public interface IInputEnabledHandler : IGlobalSubscriber
    {
        void OnEnableInput();
        void OnDisableInput();
    }
}