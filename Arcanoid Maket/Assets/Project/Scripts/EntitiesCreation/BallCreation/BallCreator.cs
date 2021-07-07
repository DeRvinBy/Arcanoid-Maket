﻿using Project.Scripts.GameEntities.Ball;
using Project.Scripts.GameSettings.GameBallSettings;
using Project.Scripts.Utils.ObjectPool.Abstract;
using UnityEngine;

namespace Project.Scripts.EntitiesCreation.BallCreation
{
    public class BallCreator : PoolObjectCreator<BallController>
    {
        [SerializeField]
        private BallSettings _ballSettings;
        
        public override BallController Instantiate()
        {
            var instance = Instantiate(_prefab, transform);
            instance.Initialize(_ballSettings);
            return instance;
        }
    }
}