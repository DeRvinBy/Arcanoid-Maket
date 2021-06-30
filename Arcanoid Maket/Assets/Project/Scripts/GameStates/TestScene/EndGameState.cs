using Project.Scripts.GameStates.Interfaces;
using UnityEngine;

namespace Project.Scripts.GameStates.TestScene
{
    public class EndGameState : Abstract.GameState
    {
        public EndGameState(IStateSwitcher stateSwitcher) : base(stateSwitcher)
        {
        }

        public override void Enter()
        {
            Debug.Log("Enter End Game State");
        }

        public override void Exit()
        {
            Debug.Log("Enter End Game State");
        }
    }
}