﻿using GameEntities.Bonuses.Enumerations;
using MyLibrary.EventSystem;

namespace EventInterfaces.BonusEvents
{
    public interface IPlatformSpeedBonusHandler : IGlobalSubscriber
    {
        void OnActivateSpeedBonus(ValueModifer modifer);
    }
}