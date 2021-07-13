using UnityEngine;

namespace Project.Scripts.Utils.ObjectPool.Config
{
    [CreateAssetMenu(fileName = "New Pools Config", menuName = "Pool/Pools Config")]
    public class PoolsConfig : ScriptableObject
    {
        [SerializeField]
        private ObjectCreatorConfig[] _creatorConfigs;

        public ObjectCreatorConfig[] CreatorConfigs => _creatorConfigs;
    }
}