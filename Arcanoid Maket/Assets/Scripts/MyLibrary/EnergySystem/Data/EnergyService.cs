using System;
using MyLibrary.EnergySystem.Data.Config;
using MyLibrary.EnergySystem.Data.Info;

namespace MyLibrary.EnergySystem.Data
{
    public class EnergyService
    {
        public event Action OnEnergyChanged;

        private int _currentEnergy;
        private EnergyConfig _config;

        public void Initialize(EnergyConfig config, int startEnergy)
        {
            _config = config;
            _currentEnergy = startEnergy;
        }

        public bool IsFullEnergy()
        {
            return _currentEnergy >= _config.MaxEnergy;
        }
        
        public EnergyInfo GetEnergyInfo()
        {
            return new EnergyInfo(_currentEnergy, _config.MaxEnergy);
        }
        
        public void AddEnergy(int value)
        {
            _currentEnergy += value;
            if (_currentEnergy > _config.MaxEnergy)
            {
                _currentEnergy = _config.MaxEnergy;
            }
            OnEnergyChanged?.Invoke();
        }
        
        public void AddEnergyOverLimit(int value)
        {
            _currentEnergy += value;
            OnEnergyChanged?.Invoke();
        }

        public bool IsEnoughEnergy(int value)
        {
            return _currentEnergy >= value;
        }

        public void RemoveEnergy(int value)
        {
            _currentEnergy -= value;
            if (_currentEnergy < 0)
            {
                _currentEnergy = 0;
            }
            OnEnergyChanged?.Invoke();
        }
    }
}