using Project.Scripts.Utils.ObjectPool.Abstract;
using UnityEngine;

namespace Project.Scripts.Utils.ObjectPool.Config
{
    [CreateAssetMenu(fileName = "New Pools Config", menuName = "Pool/Pools Config")]
    public class PoolsConfig : ScriptableObject
    {
        [SerializeField]
        private ObjectCreatorConfig<PoolObject, AbstractCreator, AbstractSettings>[] _creatorConfigs;

        public ObjectCreatorConfig<PoolObject, AbstractCreator, AbstractSettings>[] CreatorConfigs => _creatorConfigs;
    }
}