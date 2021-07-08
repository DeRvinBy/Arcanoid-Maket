using System;
using Project.Scripts.GameSettings.GameBlockSettings;

namespace Project.Scripts.GameEntities.Blocks
{
    public class BlockModel
    {
        public event Action<int> OnBlockLifeChanged;

        private BlockLifeSettings _settings;
        private int _lifeCount;

        public void Initialize(BlockLifeSettings lifeSettings)
        {
            _settings = lifeSettings;
        }

        public void SetupModel()
        {
            _lifeCount = _settings.BlockLife;
        }

        public void ReduceLife(int value)
        {
            _lifeCount -= value;
            
            OnBlockLifeChanged?.Invoke(_lifeCount);
        }
    }
}