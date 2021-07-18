using Scripts.GameEntities.Blocks;
using Scripts.GameEntities.Blocks.Enumerations;
using Scripts.Utils.EventSystem;
using UnityEngine;

namespace Scripts.EventInterfaces.BlockEvents
{
    public interface IBlockOnSceneHandler : IGlobalSubscriber
    {
        void OnCreateBlock(Vector3 position, Vector3 size, Transform parent, BlockId blockId);
        void OnBlockStartDestroyed();
        void OnDestroyBlock(BlockEntity block);
    }
}