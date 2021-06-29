using System;
using Project.Scripts.Utils.ObjectPool.Enumerations;
using UnityEngine;

namespace Project.Scripts.Utils.ObjectPool
{
    [Serializable]
    public class PoolSettings
    {
        public ObjectPoolType _type = ObjectPoolType.TestType1;
        public GameObject Prefab = null;
        public int InitialCount = 5;
    }
}