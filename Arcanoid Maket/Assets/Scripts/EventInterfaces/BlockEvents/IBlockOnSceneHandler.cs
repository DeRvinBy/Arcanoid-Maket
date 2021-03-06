using GameEntities.Blocks.Abstract;
using GameEntities.Blocks.Data;
using MyLibrary.EventSystem;
using UnityEngine;

namespace EventInterfaces.BlockEvents
{
    public interface IBlockOnSceneHandler : IGlobalSubscriber
    {
        void OnDestructibleBlockCreated();
        void OnCreateBlock(Vector3 position, Vector3 size, Transform parent, BlockProperties properties);
        void OnBlockStartDestroyed(AbstractBlock block);
        void OnDestroyBlock<T>(T block) where T : AbstractBlock;
    }
}