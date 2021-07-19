using GamePacks.Data.Level;
using Library.EventSystem;

namespace EventInterfaces.PacksEvents
{
    public interface ILevelFileChangedHandler : IGlobalSubscriber
    {
        void OnLevelFileChanged(LevelData levelData);
    }
}