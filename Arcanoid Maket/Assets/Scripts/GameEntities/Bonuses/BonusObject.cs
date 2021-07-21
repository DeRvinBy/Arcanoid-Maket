using BehaviorControllers.EntitiesControllers;
using EventInterfaces.BonusEvents;
using GameEntities.Bonuses.Interfaces;
using MyLibrary.CollisionStorage.Colliders2D;
using MyLibrary.CollisionStorage.Extensions;
using MyLibrary.EventSystem;
using MyLibrary.ObjectPool.Abstract;
using UnityEngine;

namespace GameEntities.Bonuses
{
    public class BonusObject : PoolObject
    {
        [SerializeField]
        private TriggerCollider2D _collider;

        private IBonusBehaviour _bonusBehaviour;

        public override void OnSetup()
        {
            base.OnSetup();
            _collider.OnTriggerEnter += ActivateBonus;
            _collider.RegisterCollider(this);
        }

        public override void OnReset()
        {
            base.OnReset();
            _collider.OnTriggerEnter -= ActivateBonus;
            _collider.UnregisterCollider(this);
        }

        public void SetupBehaviour(IBonusBehaviour bonusBehaviour)
        {
            _bonusBehaviour = bonusBehaviour;
        }
        
        private void ActivateBonus(Collider2D other)
        {
            if (other.IsColliderHasMonoBehaviour<PlatformController>())
            {
                _bonusBehaviour.Action();
                DestroyBonus();
            }
        }
        
        public void DestroyBonus()
        {
            EventBus.RaiseEvent<IBonusOnSceneHandler>(a => a.OnDestroyBonusObject(this));
        }
    }
}