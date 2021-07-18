using Scripts.Utils.EventSystem;

namespace Scripts.EventInterfaces.PacksEvents
{
    public interface IPackButtonPressedHandler : IGlobalSubscriber
    {
        void OnPackButtonPressed();
    }
}