using Library.EventSystem;

namespace EventInterfaces.PacksEvents
{
    public interface IPackButtonPressedHandler : IGlobalSubscriber
    {
        void OnPackButtonPressed();
    }
}