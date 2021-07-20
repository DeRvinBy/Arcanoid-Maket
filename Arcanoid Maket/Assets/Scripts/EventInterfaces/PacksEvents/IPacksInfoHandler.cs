﻿using System.Collections.Generic;
using GamePacks.Data.Packs;
using MyLibrary.EventSystem;

namespace EventInterfaces.PacksEvents
{
    public interface IPacksInfoHandler : IGlobalSubscriber
    {
        void OnPacksInfoUpdated(Dictionary<string, PackInfo> packsInfo);
    }
}