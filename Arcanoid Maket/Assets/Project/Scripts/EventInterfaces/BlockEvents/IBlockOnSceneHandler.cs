using Project.Scripts.GameEntities.Blocks;
using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.BlockEvents
{
    public interface IBlockOnSceneHandler : IGlobalSubscriber
    {
        void OnBlockCreated(BlockEntity block);
        void OnBlockStartDestroyed();
        void OnBlockEndDestroyed(BlockEntity block);
    }
}