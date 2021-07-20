using GameSettings.GameBlockSettings;
using MyLibrary.ObjectPool.Abstract;

namespace GameEntities.Blocks.Abstract
{
    public abstract class AbstractBlock : PoolObject
    {
        public virtual void Initialize(BlockSettings settings) {}
        public abstract void DestroyBlock();
    }
}