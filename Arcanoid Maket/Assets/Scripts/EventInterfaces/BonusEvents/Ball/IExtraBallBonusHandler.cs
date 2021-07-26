using MyLibrary.EventSystem;
using UnityEngine;

namespace EventInterfaces.BonusEvents.Ball
{
    public interface IExtraBallBonusHandler : IGlobalSubscriber
    {
        void OnSpawnExtraBall(Vector2 spawnPosition);
    }
}