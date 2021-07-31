using System.Collections.Generic;
using EventInterfaces.BonusEvents.Bomb;
using GameComponents.Blocks;
using GameComponents.Bonus.BonusesManagers.Bomb.Searchers;
using GameEntities.Blocks;
using GameEntities.Blocks.Abstract;
using GameSettings.GameBonusSettings.BonusesSettings;
using MyLibrary.EventSystem;
using UnityEngine;

namespace GameComponents.Bonus.BonusesManagers.Bomb
{
    public class RadiusBombBonusManager : MonoBehaviour, IRadiusBombHandler
    {
        [SerializeField]
        private GridBlocks _gridBlocks;

        [SerializeField]
        private RadiusBombBonusSettings _settings;

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
            var searcher = new BlocksRadiusSearcher(position, _gridBlocks);
            var destroyList = searcher.GetNextDestroyList();
            StartDestroyBlocks(destroyList);
        }
        
        private void StartDestroyBlocks(List<AbstractBlock> destroyBlocksList)
        {
            foreach (var block in destroyBlocksList)
            {
                if (block is IndestructibleBlock)
                {
                    block.DestroyBlock();
                }
                else
                {
                    var destructibleBlock = (DestructibleBlock) block;
                    if (!destructibleBlock.IsDamageEnoughToDestroy(_settings.BombDamage))
                    {
                        _gridBlocks.AddBlockToMatrix(block.transform.position, block);
                    }
                    destructibleBlock.DamageBlock(_settings.BombDamage);
                }
            }
        }
    }
}