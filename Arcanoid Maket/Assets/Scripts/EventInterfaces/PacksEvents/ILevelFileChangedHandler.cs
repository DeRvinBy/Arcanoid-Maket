using GamePacks.Data.Level;
using MyLibrary.EventSystem;

namespace EventInterfaces.PacksEvents
{
    public interface ILevelFileChangedHandler : IGlobalSubscriber
    {
        void OnLevelFileChanged(LevelData levelData);
    }
}