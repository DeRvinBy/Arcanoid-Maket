using EventInterfaces.BonusEvents;
using GameEntities.Bonuses.Components;
using GameEntities.Bonuses.Interfaces;
using MyLibrary.EventSystem;
using MyLibrary.ObjectPool.Abstract;
using UnityEngine;

namespace GameEntities.Bonuses
{
    public class BonusObject : PoolObject
    {
        [SerializeField]
        private BonusCollider _collider;

        private IBonusBehaviour _bonusBehaviour;

        public void Initialize()
        {
            _collider.OnTriggerEntered += ActivateBonus;
        }
        
        public void SetupBehaviour(IBonusBehaviour bonusBehaviour)
        {
            _bonusBehaviour = bonusBehaviour;
        }
        
        private void ActivateBonus()
        {
            _bonusBehaviour.Action();
            DestroyBonus();
        }
        
        public void DestroyBonus()
        {
            EventBus.RaiseEvent<IBonusOnSceneHandler>(a => a.OnDestroyBonusObject(this));
        }
    }
}