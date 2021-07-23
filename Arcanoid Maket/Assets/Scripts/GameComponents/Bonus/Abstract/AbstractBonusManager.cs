using EventInterfaces.StatesEvents;
using UnityEngine;

namespace GameComponents.Bonus.Abstract
{
    public abstract class AbstractBonusManager : MonoBehaviour, IPrepareGameplayHandler
    {
        public virtual void OnPrepareGame() {}
    }
}