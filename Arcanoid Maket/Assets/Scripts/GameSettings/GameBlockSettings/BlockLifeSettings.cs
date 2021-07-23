using System;
using UnityEngine;

namespace GameSettings.GameBlockSettings
{
    [Serializable]
    public class BlockLifeSettings
    {
        [SerializeField]
        private int _blockLife = 3;

        [SerializeField]
        private Sprite[] _cracksSprites;
        
        public int BlockLife => _blockLife;

        private int _levelSize;
        private int _spriteCount;
        
        public void Initialize()
        {
            _spriteCount = _cracksSprites.Length;
            _levelSize = _blockLife / _spriteCount + 1;
        }

        public Sprite GetSpriteByLifeCount(int blockLife)
        {
            if (blockLife < 0) return _cracksSprites[0];
            
            var index = blockLife / _levelSize;
            return _cracksSprites[index];
        }
    }
}