using System.Collections;
using GameComponents.Blocks;
using GameComponents.Bonus.BonusesManagers.Bomb.Searchers;
using GameEntities.Blocks.Abstract;
using GameEntities.Blocks.Enumerations;
using GameSettings.GameBonusSettings.BonusesSettings;
using UnityEngine;

namespace GameComponents.Bonus.BonusesManagers.Bomb.BombActions
{
    public class DamageBombAction : BombAction
    {
        [SerializeField]
        private GridBlocks _gridBlocks;
        
        [SerializeField]
        private RadiusBombBonusSettings _settings;
        
        public override void StartAction(AbstractBlocksSearcher searcher)
        {
            StartCoroutine(StartDamageBlocks(searcher));
        }
        
        private IEnumerator StartDamageBlocks(AbstractBlocksSearcher searcher)
        {
            yield return new WaitForSeconds(_settings.BlocksDestructionDelay);
            
            foreach (var block in searcher.GetNextDestroyList())
            {
                var blockType = block.BlockType;
                if (!_settings.IsBlockBelongDestructionType(blockType)) continue;
                
                if (blockType == BlockType.Indestructible)
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