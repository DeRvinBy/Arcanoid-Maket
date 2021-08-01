using System.Collections;
using GameComponents.Bonus.BonusesManagers.Bomb.Searchers;
using GameSettings.GameBonusSettings.BonusesSettings;
using UnityEngine;

namespace GameComponents.Bonus.BonusesManagers.Bomb.BombActions
{
    public class DestroyBombAction : BombAction
    {
        [SerializeField]
        private BombDestructionSettings _settings;
        
        public override void StartAction(AbstractBlocksSearcher searcher)
        {
            StartCoroutine(StartDestroyBlocks(searcher));
        }
        
        private IEnumerator StartDestroyBlocks(AbstractBlocksSearcher searcher)
        {
            while (true)
            {
                if (!searcher.IsHasNextBlocks()) break;
                
                yield return new WaitForSeconds(_settings.BlocksDestructionDelay);
                foreach (var block in searcher.GetNextDestroyList())
                {
                    if (_settings.IsBlockBelongDestructionType(block.BlockType))
                    {
                        block.DestroyBlock();
                    }
                }
            }
        }
    }
}