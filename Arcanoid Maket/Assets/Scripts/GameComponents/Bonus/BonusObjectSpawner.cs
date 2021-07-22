using System.Collections.Generic;
using GameEntities.Bonuses;
using GameEntities.Bonuses.Enumerations;
using MyLibrary.ObjectPool;
using UnityEngine;

namespace GameComponents.Bonus
{
    public class BonusObjectSpawner
    {
        private List<BonusObject> _bonusObjects;
        private BonusBehaviourFactory _behaviourFactory;

        public BonusObjectSpawner(BonusBehaviourFactory factory)
        {
            _bonusObjects = new List<BonusObject>();
            _behaviourFactory = factory;
        }
        
        public void SpawnBonusObject(BonusType type, Vector3 position, Transform parent)
        {
            var bonus = PoolsManager.Instance.GetObject<BonusObject>(position, parent);
            var behaviour = _behaviourFactory.CreateBehaviour(type,position);
            bonus.SetupBonusObject(type, behaviour);
            _bonusObjects.Add(bonus);
        }

        public void DestroyBonusObject(BonusObject bonus)
        {
            PoolsManager.Instance.ReturnObject(bonus);
            _bonusObjects.Remove(bonus);
        }

        public void DestroyAllBonusObjects()
        {
            foreach (var bonus in _bonusObjects)
            {
                PoolsManager.Instance.ReturnObject(bonus);
            }
            _bonusObjects.Clear();
        }
    }
}