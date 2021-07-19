using Scripts.GamePacks.Data.Level;
using Scripts.Utils.EventSystem;

namespace Scripts.EventInterfaces.PacksEvents
{
    public interface ILevelFileChangedHandler : IGlobalSubscriber
    {
        void OnLevelFileChanged(LevelData levelData);
    }
}