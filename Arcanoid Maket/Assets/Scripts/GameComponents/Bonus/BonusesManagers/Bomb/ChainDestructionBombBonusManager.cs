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

        private BlocksColorSearcher _colorSearcher;
        private BlocksDirectionSearcher _directionSearcher;

        private void Awake()
        {
            _colorSearcher = new BlocksColorSearcher();
            _directionSearcher = new BlocksDirectionSearcher();
        }

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
            _directionSearcher.SetupDirection(direction);
            CompleteBonus(position, _directionSearcher);
        }
        
        public void OnActivateColorBombBonus(Vector2 position)
        {
            CompleteBonus(position, _colorSearcher);
        }

        private void CompleteBonus(Vector2 position, AbstractBlocksSearcher searcher)
        {
            searcher.Setup(position, _gridBlocks);
            
            var destroyMap = searcher.GetDestroyBlocksMap();
            StartCoroutine(StartDestroyBlocks(destroyMap));
        }

        private IEnumerator StartDestroyBlocks(Dictionary<int,List<AbstractBlock>> destroyBlocksMaps)
        {
            foreach (var level in destroyBlocksMaps.Keys)
            {
                yield return new WaitForSeconds(_settings.BlocksDestructionDelay);

                foreach (var block in destroyBlocksMaps[level])
                {
                    block.DestroyBlock();   
                }
            }
        }

        public void OnPrepareGame()
        {
            StopAllCoroutines();
        }
    }
}