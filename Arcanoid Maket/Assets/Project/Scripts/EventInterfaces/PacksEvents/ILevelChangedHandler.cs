using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.PacksEvents
{
    public interface ILevelChangedHandler : IGlobalSubscriber
    {
        void OnLevelChanged(int currentLevel);
    }
}