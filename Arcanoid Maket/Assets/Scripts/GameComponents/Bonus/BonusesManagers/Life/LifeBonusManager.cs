using BehaviorControllers.EntitiesControllers;
using EventInterfaces.BonusEvents.Life;
using GameEntities.Bonuses.Enumerations;
using MyLibrary.EventSystem;
using UnityEngine;

namespace GameComponents.Bonus.BonusesManagers.Life
{
    public class LifeBonusManager : MonoBehaviour, ILifeBonusHandler
    {
        [SerializeField]
        private PlayerBallsController _playerBallsController;

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
                _playerBallsController.DecreasePlayerBallCount();
            }
            else
            {
                _playerBallsController.IncreasePlayerBallCount();
            }
        }
    }
}