﻿using Scripts.Utils.EventSystem;

namespace EventInterfaces.GameEvents
{
    public interface IEndGameHandler : IGlobalSubscriber
    {
        void OnWinGame();
        void OnLoseGame();
    }
}