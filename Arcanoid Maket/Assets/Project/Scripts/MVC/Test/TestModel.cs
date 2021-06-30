using System;
using Project.Scripts.MVC.Abstract;
using UnityEngine;

namespace Project.Scripts.MVC.Test
{
    public class TestModel : BaseModel
    {
        public event Action<int> OnLivesChanged;

        public int LivesCount { get; private set; }
        
        public override void Initialize()
        {
            Debug.Log("Model initialized");
            LivesCount = 10;
        }

        public void AddLives(int value)
        {
            LivesCount += value;
            OnLivesChanged?.Invoke(LivesCount);
        }

        public void RemoveLives(int value)
        {
            LivesCount -= value;
            OnLivesChanged?.Invoke(LivesCount);
        }
    }
}