using GamePacks.Data.Level;
using Scripts.Utils.EventSystem;

namespace EventInterfaces.PacksEvents
{
    public interface ILevelFileChangedHandler : IGlobalSubscriber
    {
        void OnLevelFileChanged(LevelData levelData);
    }
}