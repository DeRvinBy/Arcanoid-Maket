using GamePacks.Data.Packs;
using UnityEngine;

namespace GamePacks.Data.Config
{
    [CreateAssetMenu(fileName = "New Packs Container", menuName = "Packs/Packs Container")]
    public class PacksContainer : ScriptableObject
    {        
        [SerializeField]
        private Pack[] _packs;
        
        public Pack[] Packs => _packs;
    }
}