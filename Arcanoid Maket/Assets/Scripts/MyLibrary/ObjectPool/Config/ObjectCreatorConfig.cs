using System;
using MyLibrary.ObjectPool.Abstract;
using UnityEngine;

namespace MyLibrary.ObjectPool.Config
{
    [Serializable]
    public class ObjectCreatorConfig<P, C, S>
        where P : PoolObject
        where C : AbstractCreator
        where S : AbstractSettings
    {
        [SerializeField]
        private P _prefab;

        [SerializeField]
        private C _creator;

        [SerializeField]
        private S _settings;

        [SerializeField]
        private int _initialCount = 0;


        public PoolObject Prefab => _prefab;

        public AbstractCreator Creator => _creator;

        public AbstractSettings Settings => _settings;

        public int InitialCount => _initialCount;
    }
}