using Project.Scripts.GameEntities.Blocks;
using Project.Scripts.GameEntities.Blocks.Enumerations;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.EventInterfaces.BlockEvents
{
    public interface IBlockOnSceneHandler : IGlobalSubscriber
    {
        void OnCreateBlock(Vector3 position, Vector3 size, Transform parent, BlockId blockId);
        void OnBlockStartDestroyed();
        void OnDestroyBlock(BlockEntity block);
    }
}