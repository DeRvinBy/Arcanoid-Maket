using System;
using System.Collections.Generic;
using Project.Scripts.GameStates.Abstract;

namespace Project.Scripts.GameStates.TestScene
{
    public class TestStateMachine : StateMachine
    {
        protected override Dictionary<Type, GameState> CreateStatesMap()
        {
            var map = new Dictionary<Type, GameState>
            {
                {typeof(StartGameState), new StartGameState(this)},
                {typeof(EndGameState), new EndGameState(this)}
            };
            return map;
        }

        protected override Type GetStartStateType()
        {
            return typeof(StartGameState);
        }
    }
}