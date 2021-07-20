using GameSettings.GameBlockSettings;
using Library.ObjectPool.Abstract;

namespace GameEntities.Blocks.Abstract
{
    public abstract class AbstractBlock : PoolObject
    {
        public virtual void Initialize(BlockSettings settings) {}
    }
}