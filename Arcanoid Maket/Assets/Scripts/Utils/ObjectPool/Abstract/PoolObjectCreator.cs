using Scripts.Utils.ObjectPool.Config;
using UnityEngine;

namespace Scripts.Utils.ObjectPool.Abstract
{
    public abstract class PoolObjectCreator<P, S> : AbstractCreator
        where P : PoolObject
        where S : AbstractSettings
    {
        protected P _prefab;
        protected S _settings;
        protected Transform _parent;

        public override void Initialize(ObjectCreatorConfig<PoolObject, AbstractCreator, AbstractSettings> config, Transform parent)
        {
            _prefab = config.Prefab as P;
            _settings = config.Settings as S;
            _parent = parent;
        }

        public override Transform Parent => _parent;
    }
}