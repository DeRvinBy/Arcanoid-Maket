using GameEntities.Blocks.Abstract;
using GameEntities.Blocks.Behaviour;
using GameEntities.Blocks.Enumerations;
using GameSettings.GameBlockSettings;
using UnityEngine;

namespace GameEntities.Blocks
{
    public class IndestructibleBlock : AbstractBlock
    {
        [SerializeField]
        private BlockSprite _sprite;
        
        public override void Initialize(BlockSettings settings)
        {
            _sprite.Initialize();
            var visualSettings = settings.GetBlockSettings(BlockSpriteId.Iron); 
            _sprite.SetupSprite(visualSettings.Sprite);
        }
    }
}