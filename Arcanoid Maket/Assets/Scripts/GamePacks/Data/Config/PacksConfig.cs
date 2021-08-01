using System.Collections.Generic;
using GamePacks.Data.Packs;
using UnityEngine;

namespace GamePacks.Data.Config
{
    [CreateAssetMenu(fileName = "New PacksConfig", menuName = "Packs/Packs Config")]
    public class PacksConfig : ScriptableObject
    {
        [SerializeField]
        private PacksContainer _currentContainer;

        [SerializeField]
        private bool _isDebugEnable = false;
        
        [SerializeField]
        private string _debugPack = "test_pack";
        
        [SerializeField]
        private int _debugLevelId = 2;
        
        public string FirstPackKey => _currentContainer.Packs[0].Key;
        public string DebugPack => _debugPack;
        public int DebugLevelId => _debugLevelId;
        public bool IsDebugEnable => _isDebugEnable;

        public Dictionary<string, Pack> GetPacksMap()
        {
            var map = new Dictionary<string, Pack>();
            foreach (var pack in _currentContainer.Packs)
            {
                map.Add(pack.Key, pack);
            }

            return map;
        }
    }
}