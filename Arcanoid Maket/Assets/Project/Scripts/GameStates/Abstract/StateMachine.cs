using System;
using System.Collections.Generic;
using Project.Scripts.GameStates.Interfaces;
using Project.Scripts.Scenes;
using UnityEngine;

namespace Project.Scripts.GameStates.Abstract
{
    public abstract class StateMachine : MonoBehaviour, IStateSwitcher
    {
        protected Scene _scene;
        protected GameState _currentState;
        protected Dictionary<Type, GameState> _statesMap;

        public void Initialize(Scene scene)
        {
            _scene = scene;
            _statesMap = CreateStatesMap();
            var startType = GetStartStateType();
            _currentState = _statesMap[startType];
            
            _currentState.Enter();
        }

        protected abstract Dictionary<Type, GameState> CreateStatesMap();
        protected abstract Type GetStartStateType();

        public void SwitchState<T>() where T : GameState
        {
            var type = typeof(T);
            _currentState.Exit();
            _currentState = _statesMap[type];
            _currentState.Enter();
        }
    }
}