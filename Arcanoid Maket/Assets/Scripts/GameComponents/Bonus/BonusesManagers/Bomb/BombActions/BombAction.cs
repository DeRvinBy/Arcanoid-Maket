using EventInterfaces.StatesEvents;
using GameComponents.Bonus.BonusesManagers.Bomb.Searchers;
using UnityEngine;

namespace GameComponents.Bonus.BonusesManagers.Bomb.BombActions
{
    public abstract class BombAction : MonoBehaviour, IPrepareGameplayHandler
    {
        public abstract void StartAction(AbstractBlocksSearcher searcher);
        public void OnPrepareGame()
        {
            StopAllCoroutines();
        }
    }
}