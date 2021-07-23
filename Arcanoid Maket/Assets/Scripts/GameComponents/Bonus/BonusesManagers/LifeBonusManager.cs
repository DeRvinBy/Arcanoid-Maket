using System;
using BehaviorControllers.EntitiesControllers;
using EventInterfaces.BonusEvents;
using GameComponents.Bonus.Abstract;
using GameEntities.Bonuses.Enumerations;
using MyLibrary.EventSystem;
using UnityEngine;

namespace GameComponents.Bonus.BonusesManagers
{
    public class LifeBonusManager : AbstractBonusManager, ILifeBonusHandler
    {
        [SerializeField]
        private LifeController _lifeController;

        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }
        
        private void OnDisable()
        {
            EventBus.Subscribe(this);
        }

        public void OnActivateLifeBonus(ValueModifer modifer)
        {
            if (modifer == ValueModifer.Decrease)
            {
                _lifeController.DecreaseLifeCount();
            }
            else
            {
                _lifeController.IncreaseLifeCount();
            }
        }
    }
}