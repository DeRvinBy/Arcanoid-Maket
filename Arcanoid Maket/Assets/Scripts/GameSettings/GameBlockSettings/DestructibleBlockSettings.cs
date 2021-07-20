using System;
using UnityEngine;

namespace GameSettings.GameBlockSettings
{
    [Serializable]
    public class DestructibleBlockSettings
    {
        [SerializeField]
        private Sprite _blockSprite;

        [SerializeField]
        private Color _particleColor;
        
        public Sprite Sprite => _blockSprite;
        public Color ParticleColor => _particleColor;
    }
}