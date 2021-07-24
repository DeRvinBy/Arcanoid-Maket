using System;
using System.Collections;
using System.Collections.Generic;
using EventInterfaces.BonusEvents.Bomb;
using EventInterfaces.StatesEvents;
using GameComponents.Blocks;
using GameComponents.Bonus.BonusesManagers.Bomb.Data;
using GameEntities.Blocks;
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
            var destroyMap = new DirectionBombDestroyBlocksMap(startCoords, blocksMatrix);
            
            if (direction == BombBonusDirection.Horizontal)
            {
                destroyMap.FillDestroyBlocksMap(1, new Vector2Int(1, 0));
                destroyMap.FillDestroyBlocksMap(1, new Vector2Int(-1, 0));
            }
            else
            {
                destroyMap.FillDestroyBlocksMap(1, new Vector2Int(0, 1));
                destroyMap.FillDestroyBlocksMap(1, new Vector2Int(0, -1));
            }

            StartCoroutine(StartDestroyBlocks(destroyMap.DestroyBlocksMap));
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