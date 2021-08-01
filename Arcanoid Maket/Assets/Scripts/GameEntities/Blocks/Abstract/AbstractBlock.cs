using GameEntities.Blocks.Enumerations;
using GameSettings.GameBlockSettings;
using MyLibrary.ObjectPool.Abstract;

namespace GameEntities.Blocks.Abstract
{
    public abstract class AbstractBlock : PoolObject
    {
        public BlockType BlockType { get; protected set; }
        public virtual void Initialize(BlockSettings settings) {}
        public abstract void DestroyBlock();
    }
}