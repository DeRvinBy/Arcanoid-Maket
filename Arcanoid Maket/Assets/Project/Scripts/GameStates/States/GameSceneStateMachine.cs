using System;
using System.Collections.Generic;
using Project.Scripts.GameStates.Abstract;

namespace Project.Scripts.GameStates.States
{
    public class GameSceneStateMachine : StateMachine
    {
        protected override Dictionary<Type, GameState> CreateStatesMap()
        {
            var map = new Dictionary<Type, GameState>()
            {
                {typeof(MainGameState), new MainGameState(this)}
            };
            return map;
        }

        protected override Type GetStartStateType()
        {
            return typeof(MainGameState);
        }
    }
}