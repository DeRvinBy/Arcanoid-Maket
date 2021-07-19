using GameEntities.Blocks;
using GameEntities.Blocks.Enumerations;
using Library.EventSystem;
using UnityEngine;

namespace EventInterfaces.BlockEvents
{
    public interface IBlockOnSceneHandler : IGlobalSubscriber
    {
        void OnCreateBlock(Vector3 position, Vector3 size, Transform parent, BlockId blockId);
        void OnBlockStartDestroyed();
        void OnDestroyBlock(BlockEntity block);
    }
}