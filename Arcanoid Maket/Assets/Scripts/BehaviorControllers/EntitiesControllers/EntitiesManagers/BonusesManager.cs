using BehaviorControllers.Abstract;
using EventInterfaces.BonusEvents;
using GameComponents.Bonus;
using GameEntities.Bonuses;
using GameEntities.Bonuses.Enumerations;
using GameSettings.GameBonusSettings;
using MyLibrary.EventSystem;
using UnityEngine;

namespace BehaviorControllers.EntitiesControllers.EntitiesManagers
{
    public class BonusesManager : EntityController, IBonusOnSceneHandler
    {
        [SerializeField]
        private BonusesSettingsContainer _settings;
        
        private BonusBehaviourFactory _behaviourFactory;
        private BonusObjectSpawner _spawner;

        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }

        public override void Initialize()
        {
            _behaviourFactory = new BonusBehaviourFactory(_settings);
            _spawner = new BonusObjectSpawner(_behaviourFactory);
        }

        public void OnCreateBonusObject(BonusType type, Vector3 position)
        {
            _spawner.SpawnBonusObject(type, position, transform);
        }

        public void OnDestroyBonusObject(BonusObject bonus)
        {
            _spawner.DestroyBonusObject(bonus);
        }
    }
}