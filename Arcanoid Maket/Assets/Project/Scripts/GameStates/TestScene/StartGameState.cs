using Project.Scripts.GameStates.Abstract;
using Project.Scripts.GameStates.Interfaces;
using Project.Scripts.MVC.Test.Interfaces;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.GameStates.TestScene
{
    public class StartGameState : GameState, IGameEndedEvent
    {
        public StartGameState(IStateSwitcher stateSwitcher) : base(stateSwitcher)
        {
            EventBus.Subscribe(this);
        }

        public override void Enter()
        {
            Debug.Log("Enter Game State");
        }

        public override void Exit()
        {
            Debug.Log("Exit Game State");
        }

        public void EndGame()
        {
            _stateSwitcher.SwitchState<EndGameState>();
        }
    }
}