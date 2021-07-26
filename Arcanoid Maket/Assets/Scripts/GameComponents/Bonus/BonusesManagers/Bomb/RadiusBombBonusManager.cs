using System.Collections;
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

        private BlocksRadiusSearcher _searcher;

        private void Awake()
        {
            _searcher = new BlocksRadiusSearcher();
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
            _searcher.Setup(position, _gridBlocks);
            
            var destroyMap = _searcher.GetDestroyBlocksMap();
            StartDestroyBlocks(destroyMap);
        }
        
        private void StartDestroyBlocks(Dictionary<int, List<AbstractBlock>> destroyBlocksMaps)
        {
            foreach (var level in destroyBlocksMaps.Keys)
            {
                foreach (var block in destroyBlocksMaps[level])
                {
                    if (block is IndestructibleBlock)
                    {
                        block.DestroyBlock();
                    }
                    else
                    {
                        ((DestructibleBlock)block).DamageBlock(_settings.BombDamage);
                    }
                }
            }
        }
    }
}