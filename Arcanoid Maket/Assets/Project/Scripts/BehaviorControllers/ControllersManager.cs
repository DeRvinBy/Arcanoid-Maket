﻿using System.Linq;
using Project.Scripts.BehaviorControllers.Abstract;
using UnityEngine;

namespace Project.Scripts.BehaviorControllers
{
    public class ControllersManager : MonoBehaviour
    {
        [SerializeField]
        private GameController[] _gameControllers;

        [SerializeField]
        private EntityController[] _entityControllers;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            InitializeEntityControllers();
            InitializeGameControllers();
        }
        
        private void InitializeEntityControllers()
        {
            foreach (var controller in _entityControllers)
            {
                controller.Initialize();
            }
        }
        
        private void InitializeGameControllers()
        {
            foreach (var controller in _gameControllers)
            {
                controller.Initialize(this);
            }
        }

        public T GetEntityController<T>() where T : EntityController
        {
            return (T) _entityControllers.First(c => c is T);
        }
    }
}