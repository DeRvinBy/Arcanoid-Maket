﻿using Project.Scripts.EventInterfaces.StatesInterfaces;
using Project.Scripts.GameStates.Abstract;
using Project.Scripts.GameStates.Interfaces;
using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.GameStates.States
{
    public class MainGameState : GameState
    {
        public MainGameState(IStateSwitcher stateSwitcher) : base(stateSwitcher)
        {
        }

        public override void Enter()
        {
            EventBus.RaiseEvent<IMainGameStateEvent>(a => a.StartController());
        }

        public override void Exit()
        {
            
        }
    }
}