using MyLibrary.EventSystem;
using UnityEngine;

namespace EventInterfaces.BonusEvents
{
    public interface IExtraBallBonusHandler : IGlobalSubscriber
    {
        void OnSpawnExtraBall(Vector2 spawnPosition);
    }
}