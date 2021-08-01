using EventInterfaces.BonusEvents.Bomb;
using GameComponents.Blocks;
using GameComponents.Bonus.BonusesManagers.Bomb.BombActions;
using GameComponents.Bonus.BonusesManagers.Bomb.Searchers;
using MyLibrary.EventSystem;
using UnityEngine;

namespace GameComponents.Bonus.BonusesManagers.Bomb
{
    public class ColorBombBonusManager : MonoBehaviour, IColorBombBonusHandler
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
        
        public void OnActivateColorBombBonus(Vector2 position)
        {
            var searcher = new BlocksColorSearcher(position, _gridBlocks);
            _bombAction.StartAction(searcher);
        }
    }
}