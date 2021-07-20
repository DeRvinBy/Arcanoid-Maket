using System.Collections.Generic;
using UnityEngine;

namespace GamePacks.Data.Packs
{
    [CreateAssetMenu(fileName = "New PacksConfig", menuName = "Packs/Packs Config")]
    public class PacksConfig : ScriptableObject
    {
        [SerializeField]
        private Pack[] _packs;

        [SerializeField]
        private string _debugPack = "test_pack";
        
        [SerializeField]
        private int _debugLevelId = 2;
        
        public Pack FirstPack => _packs[0];
        public string DebugPack => _debugPack;
        public int DebugLevelId => _debugLevelId;

        public Dictionary<string, Pack> GetPacksMap()
        {
            var map = new Dictionary<string, Pack>();
            foreach (var pack in _packs)
            {
                map.Add(pack.Key, pack);
            }
            return map;
        }
    }
}