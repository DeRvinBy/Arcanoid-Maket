﻿using EventInterfaces.BonusEvents;
using GameEntities.Bonuses.Behaviour.Abstract;
using GameEntities.Bonuses.Enumerations;
using MyLibrary.EventSystem;

namespace GameEntities.Bonuses.Behaviour
{
    public class BallVelocityBonusBehaviour : ValueModiferBonusBehaviour
    {
        public BallVelocityBonusBehaviour(ValueModifer modifer) : base(modifer)
        {
        }
        
        public override void Action()
        {
            EventBus.RaiseEvent<IBallVelocityBonusHandler>(a => a.ActivateVelocityBonus(_modifer));
        }
    }
}