using GameEntities.Bonuses.Enumerations;
using GameEntities.Bonuses.Interfaces;

namespace GameEntities.Bonuses.Behaviour.Abstract
{
    public abstract class ValueModiferBonusBehaviour : IBonusBehaviour
    {
        protected ValueModifer _modifer;

        public ValueModiferBonusBehaviour(ValueModifer modifer)
        {
            _modifer = modifer;
        }
        
        public abstract void Action();
    }
}