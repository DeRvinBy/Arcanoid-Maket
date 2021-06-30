using System;
using System.Collections.Generic;
using Project.Scripts.GameStates.Interfaces;
using Project.Scripts.Scenes.Abstract;
using UnityEngine;

namespace Project.Scripts.GameStates.Abstract
{
    public abstract class StateMachine : MonoBehaviour, IStateSwitcher
    {
        protected GameState _currentState;
        protected Dictionary<Type, GameState> _states;

        public abstract void Initialize(Scene scene);
        
        public void SwitchState<T>() where T : GameState
        {
            var type = typeof(T);
            _currentState.Exit();
            _currentState = _states[type];
            _currentState.Enter();
        }
    }
}