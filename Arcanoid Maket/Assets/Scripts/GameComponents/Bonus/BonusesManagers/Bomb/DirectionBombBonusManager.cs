using EventInterfaces.BonusEvents.Bomb;
using GameComponents.Blocks;
using GameComponents.Bonus.BonusesManagers.Bomb.BombActions;
using GameComponents.Bonus.BonusesManagers.Bomb.Searchers;
using GameEntities.Bonuses.Enumerations;
using MyLibrary.EventSystem;
using UnityEngine;

namespace GameComponents.Bonus.BonusesManagers.Bomb
{
    public class DirectionBombBonusManager : MonoBehaviour, IDirectionBombBonusHandler
    {
        [SerializeField]
        private GridBlocks _gridBlocks;

        [SerializeField]
        private BombAction _bombAction;
        
        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Subscribe(this);
        }

        public void OnActivateDirectionBombBonus(Vector2 position, BombBonusDirection direction)
        {
            var searcher = new BlocksDirectionSearcher(direction, position, _gridBlocks);
            _bombAction.StartAction(searcher);
        }
    }
}