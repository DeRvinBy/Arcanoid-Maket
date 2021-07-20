using GameEntities.Blocks.Abstract;
using GameEntities.Blocks.Behaviour;
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
            _sprite.SetupSprite(settings.IndestructibleSettings.Sprite);
        }
    }
}