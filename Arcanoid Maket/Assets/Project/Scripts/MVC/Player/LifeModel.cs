using System;
using Project.Scripts.GameSettings.PlayerSettings;

namespace Project.Scripts.MVC.Player
{
    public class LifeModel
    {
        public event Action<int> OnLifeCountChanged;

        private int _lifeCount;

        public void Initialize(LifeSettings settings)
        {
            _lifeCount = settings.StartLifeCount;
        }

        public void ReduceLifeByOne()
        {
            _lifeCount--;
            OnLifeCountChanged?.Invoke(_lifeCount);
        }
    }
}