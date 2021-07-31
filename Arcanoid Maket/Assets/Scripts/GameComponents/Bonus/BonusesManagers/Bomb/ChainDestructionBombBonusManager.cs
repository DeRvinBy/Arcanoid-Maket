using System.Collections;
using System.Collections.Generic;
using EventInterfaces.BonusEvents.Bomb;
using EventInterfaces.StatesEvents;
using GameComponents.Blocks;
using GameComponents.Bonus.BonusesManagers.Bomb.Searchers;
using GameEntities.Blocks.Abstract;
using GameEntities.Bonuses.Enumerations;
using GameSettings.GameBonusSettings.BonusesSettings;
using MyLibrary.EventSystem;
using UnityEngine;

namespace GameComponents.Bonus.BonusesManagers.Bomb
{
    public class ChainDestructionBombBonusManager : MonoBehaviour, IDirectionBombBonusHandler, IColorBombBonusHandler, IPrepareGameplayHandler
    {
        [SerializeField]
        private GridBlocks _gridBlocks;

        [SerializeField]
        private BombDestructionSettings _settings;

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
            StartCoroutine(StartDestroyBlocks(searcher));
        }
        
        public void OnActivateColorBombBonus(Vector2 position)
        {
            var searcher = new BlocksColorSearcher(position, _gridBlocks);
            StartCoroutine(StartDestroyBlocks(searcher));
        }

        private IEnumerator StartDestroyBlocks(AbstractBlocksSearcher searcher)
        {
            while (true)
            {
                yield return new WaitForSeconds(_settings.BlocksDestructionDelay);

                var destroyBlocks = searcher.GetNextDestroyList();
                foreach (var block in destroyBlocks)
                {
                    block.DestroyBlock();
                }
                
                if (!searcher.IsHasNextBlocks())
                {
                    break;
                }
            }
        }

        public void OnPrepareGame()
        {
            StopAllCoroutines();
        }
    }
}