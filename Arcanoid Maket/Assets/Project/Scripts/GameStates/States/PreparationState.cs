using Project.Scripts.Architecture.Abstract;
using Project.Scripts.Architecture.Interfaces;
using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.GameStates.States
{
    public class PreparationState : GameState
    {
        public PreparationState(IStateSwitcher stateSwitcher) : base(stateSwitcher)
        {
        }

        public override void Enter()
        {
            EventBus.RaiseEvent<IPrepareGameHandler>(a => a.OnPrepareGame());
            _stateSwitcher.SwitchState<MainGameState>();
        }

        public override void Exit()
        {
            
        }
    }
}