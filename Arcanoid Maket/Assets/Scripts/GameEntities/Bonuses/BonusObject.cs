using BehaviorControllers.EntitiesControllers;
using EventInterfaces.BonusEvents;
using GameEntities.Bonuses.Enumerations;
using GameEntities.Bonuses.Interfaces;
using GameEntities.Bonuses.ObjectBehaviour;
using GameSettings.GameBonusSettings;
using GameSettings.GameBonusSettings.ObjectSettings;
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
        private BonusObjectBehaviour _objectBehaviour;
        
        [SerializeField]
        private TriggerCollider2D _collider;

        private BonusObjectSettings _settings;
        private IBonusBehaviour _bonusBehaviour;

        public void Initialize(BonusObjectSettings settings)
        {
            _settings = settings;
            _objectBehaviour.Initialize(settings.BonusGravityScale);
        }
        
        public void SetupBonusObject(BonusType type, IBonusBehaviour bonusBehaviour)
        {
            _bonusBehaviour = bonusBehaviour;
            var bonusSprite = _settings.GetBonusSprite(type);
            _objectBehaviour.SetupBehaviour(bonusSprite);
        }
        
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