using System;

namespace Project.Scripts.GameEntities.Ball.SceneBalls
{
    public class SceneBallsModel
    {
        public event Action<int> OnBallCountReduced;
        
        private int _ballCount;

        public void StartModel()
        {
            _ballCount = 0;
        }
        
        public void IncreaseBallCount()
        {
            _ballCount++;
        }

        public void ReduceBallCount()
        {
            _ballCount--;
            OnBallCountReduced?.Invoke(_ballCount);
        } 
    }
}