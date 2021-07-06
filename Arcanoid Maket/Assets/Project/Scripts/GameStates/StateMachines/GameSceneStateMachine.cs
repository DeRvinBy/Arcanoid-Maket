using System;
using System.Collections.Generic;
using Project.Scripts.GameStates.Abstract;
using Project.Scripts.GameStates.States;
using Project.Scripts.Scenes;

namespace Project.Scripts.GameStates.StateMachines
{
    public class GameSceneStateMachine : StateMachine
    {
        protected override Dictionary<Type, GameState> CreateStatesMap(Scene scene)
        {
            var map = new Dictionary<Type, GameState>()
            {
                {typeof(MainGameState), new MainGameState(this)},
                {typeof(LoseGameState), new LoseGameState(scene, this)},
                {typeof(WinGameState), new WinGameState(scene, this)}
            };
            return map;
        }

        protected override Type GetStartStateType()
        {
            return typeof(MainGameState);
        }
    }
}