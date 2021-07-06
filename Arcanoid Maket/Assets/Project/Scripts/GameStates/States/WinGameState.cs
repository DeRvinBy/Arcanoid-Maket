﻿using Project.Scripts.GameStates.Abstract;
using Project.Scripts.GameStates.Interfaces;
using Project.Scripts.Scenes;
using Project.Scripts.UI.PopupUI;

namespace Project.Scripts.GameStates.States
{
    public class WinGameState : GameState
    {
        private PopupsController _popupsController;
        
        public WinGameState(Scene scene, IStateSwitcher stateSwitcher) : base(stateSwitcher)
        {
            _popupsController = scene.GetController<PopupsController>();
        }

        public override void Enter()
        {
            _popupsController.ShowPopup<WinPopup>();
        }

        public override void Exit()
        {
            
        }
    }
}