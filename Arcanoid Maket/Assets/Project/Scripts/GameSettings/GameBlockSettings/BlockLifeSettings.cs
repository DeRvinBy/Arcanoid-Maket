using System;
using UnityEngine;

namespace Project.Scripts.GameSettings.GameBlockSettings
{
    [Serializable]
    public class BlockLifeSettings
    {
        [SerializeField]
        private int _blockLife = 3;

        [SerializeField]
        private Sprite[] _cracksSprites = null;
        
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
            var index = blockLife / _levelSize;
            return _cracksSprites[index];
        }
    }
}