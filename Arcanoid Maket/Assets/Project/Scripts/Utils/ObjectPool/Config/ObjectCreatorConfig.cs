using System;
using UnityEngine;

namespace Project.Scripts.Utils.ObjectPool.Config
{
    [Serializable]
    public class ObjectCreatorConfig
    {
        [SerializeField]
        private string _creatorCreatorPrefabName;

        [SerializeField]
        private int _initialCount = 0;

        public string CreatorPrefabName => _creatorCreatorPrefabName;
        public int InitialCount => _initialCount;
    }
}