using GameEntities.Blocks.Abstract;
using GameEntities.Blocks.Enumerations;
using Library.EventSystem;
using UnityEngine;

namespace EventInterfaces.BlockEvents
{
    public interface IBlockOnSceneHandler : IGlobalSubscriber
    {
        void OnDestructibleBlockCreated();
        void OnCreateBlock(Vector3 position, Vector3 size, Transform parent, BlockId blockId);
        void OnBlockStartDestroyed();
        void OnDestroyBlock<T>(T block) where T : AbstractBlock;
    }
}