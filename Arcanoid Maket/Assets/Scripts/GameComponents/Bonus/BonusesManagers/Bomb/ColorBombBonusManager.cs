using System.Collections;
using System.Collections.Generic;
using EventInterfaces.BonusEvents.Bomb;
using EventInterfaces.StatesEvents;
using GameComponents.Blocks;
using GameComponents.Bonus.BonusesManagers.Bomb.Searchers;
using GameEntities.Blocks.Abstract;
using GameSettings.GameBonusSettings.BonusesSettings;
using MyLibrary.EventSystem;
using UnityEngine;

namespace GameComponents.Bonus.BonusesManagers.Bomb
{
    public class ColorBombBonusManager : MonoBehaviour, IColorBombBonusHandler, IPrepareGameplayHandler
    {
        [SerializeField]
        private GridBlocks _gridBlocks;
        
        [SerializeField]
        private BombDestructionSettings _settings;
        
        private BlocksColorSearcher _searcher;
        
        private void Awake()
        {
            _searcher = new BlocksColorSearcher();
        }
        
        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }
        
        public void OnActivateBonus(Vector2 position)
        {
            var startCoords = _gridBlocks.GetBlocksCoordinates(position);
            var blocksMatrix = _gridBlocks.GetBlocksMatrix();
            _searcher.Setup(startCoords, blocksMatrix);
            
            var destroyMap = _searcher.GetDestroyBlocksMap();
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