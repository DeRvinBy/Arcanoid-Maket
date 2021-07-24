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
    public class DirectionBombBonusManager : MonoBehaviour, IDirectionBombBonusHandler, IPrepareGameplayHandler
    {
        [SerializeField]
        private GridBlocks _gridBlocks;

        [SerializeField]
        private DirectionBombBonusSettings _settings;

        private BlocksDirectionSearcher _searcher;

        private void Awake()
        {
            _searcher = new BlocksDirectionSearcher();
        }

        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Subscribe(this);
        }

        public void OnActivateBonus(Vector2 position, BombBonusDirection direction)
        {
            var startCoords = _gridBlocks.GetBlocksCoordinates(position);
            var blocksMatrix = _gridBlocks.GetBlocksMatrix();
            _searcher.Setup(startCoords, blocksMatrix);
            List<Vector2Int> moveDirections;
            
            if (direction == BombBonusDirection.Horizontal)
            {
                moveDirections = _settings.HorizontalMoveDirections;
            }
            else
            {
                moveDirections = _settings.VerticalMoveDirections;
            }

            var destroyMap = _searcher.GetDestroyBlocksMap(moveDirections);
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