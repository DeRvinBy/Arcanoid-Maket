using System;

namespace Project.Scripts.GameEntities.FieldBlocks
{
    public class FieldBlocksModel
    {
        public event Action<int> OnBlockCountReduced;
        
        private int _blockCount;

        public void SetBlockCount(int value)
        {
            _blockCount = value;
        }

        public void ReduceBLockCount()
        {
            _blockCount--;
            OnBlockCountReduced?.Invoke(_blockCount);
        }
    }
}