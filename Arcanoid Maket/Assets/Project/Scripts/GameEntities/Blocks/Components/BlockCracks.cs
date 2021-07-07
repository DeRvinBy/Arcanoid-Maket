﻿using Project.Scripts.GameSettings.GameBlockSettings;
using Project.Scripts.Utils.Extensions;
using UnityEngine;

namespace Project.Scripts.GameEntities.Blocks.Components
{
    public class BlockCracks : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        private BlockLifeSettings _lifeSettings;

        public void Initialize(BlockLifeSettings settings)
        {
            _lifeSettings = settings;
            _spriteRenderer.SetTransformScaleOneByBoundsSize();
        }

        public void SetupBlockCracks()
        {
            _spriteRenderer.enabled = true;
            _spriteRenderer.sprite = null;
        }

        public void UpdateBlockCracks(int lifeCount)
        {
            var newSprite = _lifeSettings.GetSpriteByLifeCount(lifeCount);
            _spriteRenderer.sprite = newSprite;
        }

        public void DisableBlockCracks()
        {
            _spriteRenderer.enabled = false;
        }
    }
}