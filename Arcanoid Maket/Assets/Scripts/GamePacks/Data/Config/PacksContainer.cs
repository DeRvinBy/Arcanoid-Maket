using GamePacks.Data.Packs;
using UnityEngine;

namespace GamePacks.Data.Config
{
    [CreateAssetMenu(fileName = "New Packs Container", menuName = "Packs/Packs Container")]
    public class PacksContainer : ScriptableObject
    {
        [SerializeField]
        private int _version;
        
        [SerializeField]
        private Pack[] _packs;
        
        public int Version => _version;
        public Pack[] Packs => _packs;
    }
}