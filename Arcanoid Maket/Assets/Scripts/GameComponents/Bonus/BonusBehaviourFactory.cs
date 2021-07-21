using GameEntities.Bonuses.Behaviour;
using GameEntities.Bonuses.Enumerations;
using GameEntities.Bonuses.Interfaces;

namespace GameComponents.Bonus
{
    public class BonusBehaviourFactory
    {
        public IBonusBehaviour CreateBehaviour(BonusType type)
        {
            switch (type)
            {
                case BonusType.BallVelocityUp:
                    return new BallVelocityBonusBehaviour(ValueModifer.Increase);
                case BonusType.BallVelocityDown:
                    return new BallVelocityBonusBehaviour(ValueModifer.Decrease);
            }

            return null;
        }
    }
}