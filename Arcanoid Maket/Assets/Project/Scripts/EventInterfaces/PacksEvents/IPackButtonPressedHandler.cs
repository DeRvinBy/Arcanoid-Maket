using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.PacksEvents
{
    public interface IPackButtonPressedHandler : IGlobalSubscriber
    {
        void OnPackButtonPressed();
    }
}