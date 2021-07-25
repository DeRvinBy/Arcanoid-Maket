using MyLibrary.EventSystem;

namespace EventInterfaces.StatesEvents
{
    public interface IClearGameSceneHandler : IGlobalSubscriber
    {
        void OnClearObjects();
    }
}