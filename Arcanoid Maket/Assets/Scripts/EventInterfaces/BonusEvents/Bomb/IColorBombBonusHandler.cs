using MyLibrary.EventSystem;
using UnityEngine;

namespace EventInterfaces.BonusEvents.Bomb
{
    public interface IColorBombBonusHandler : IGlobalSubscriber
    {
        void OnActivateColorBombBonus(Vector2 position);
    }
}