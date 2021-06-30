using System;
using System.Collections.Generic;
using Project.Scripts.GameStates.Abstract;
using Project.Scripts.MVC.Abstract;
using UnityEngine;

namespace Project.Scripts.Scenes.Abstract
{
    public abstract class Scene : MonoBehaviour
    {
        [SerializeField]
        private StateMachine _stateMachine;

        protected Dictionary<Type, BaseController> _controllersMap;

        public void Initialize()
        {
            InitializeStateMachine();
        }
        
        private void InitializeStateMachine()
        {
            _stateMachine.Initialize(this);
        }

        protected abstract void CreateControllersMap();
    }
}