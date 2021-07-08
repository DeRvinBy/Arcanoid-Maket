using Project.Scripts.Packs.EventArguments;
using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.PacksEvents
{
    public interface ILevelChangedHandler : IGlobalSubscriber
    {
        void OnLevelChanged(LevelArguments levelArguments);
    }
}