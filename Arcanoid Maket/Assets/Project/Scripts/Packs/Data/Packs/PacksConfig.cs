using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Packs.Data.Packs
{
    [CreateAssetMenu(fileName = "New PacksConfig", menuName = "Packs/Packs Config")]
    public class PacksConfig : ScriptableObject
    {
        [SerializeField]
        private Pack[] _packs;

        public Pack FirstPack => _packs[0];
        
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