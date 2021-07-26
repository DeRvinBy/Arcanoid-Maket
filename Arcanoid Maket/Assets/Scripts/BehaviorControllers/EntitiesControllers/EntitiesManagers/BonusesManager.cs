using BehaviorControllers.Abstract;
using EventInterfaces.BonusEvents;
using EventInterfaces.StatesEvents;
using GameComponents.Bonus;
using GameEntities.Bonuses;
using GameEntities.Bonuses.Enumerations;
using MyLibrary.EventSystem;
using UnityEngine;

namespace BehaviorControllers.EntitiesControllers.EntitiesManagers
{
    public class BonusesManager : EntityController, IClearGameSceneHandler, IEndGameplayHandler, IBonusOnSceneHandler
    {
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
            _behaviourFactory = new BonusBehaviourFactory();
            _spawner = new BonusObjectSpawner(_behaviourFactory);
        }

        public void OnStartBonusAtPosition(BonusType type, Vector3 position)
        {
            var behaviour = _behaviourFactory.CreateBehaviour(type, position);
            behaviour.Action();
        }

        public void OnCreateBonusObject(BonusType type, Vector3 position)
        {
            _spawner.SpawnBonusObject(type, position, transform);
        }

        public void OnDestroyBonusObject(BonusObject bonus)
        {
            _spawner.DestroyBonusObject(bonus);
        }

        public void OnClearObjects()
        {
            _spawner.DestroyAllBonusObjects();
        }

        public void OnEndGame()
        {
            _spawner.DestroyAllBonusObjects();
        }
    }
}