using GameEntities.Bonuses;
using GameEntities.Bonuses.Enumerations;
using MyLibrary.EventSystem;
using UnityEngine;

namespace EventInterfaces.BonusEvents
{
    public interface IBonusOnSceneHandler : IGlobalSubscriber
    {
        void OnCreateBonusObject(BonusType type, Vector3 position);
        void OnDestroyBonusObject(BonusObject bonus);
    }
}