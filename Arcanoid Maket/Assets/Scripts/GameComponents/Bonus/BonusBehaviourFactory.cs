using GameEntities.Bonuses.BonusBehaviour;
using GameEntities.Bonuses.BonusBehaviour.Ball;
using GameEntities.Bonuses.BonusBehaviour.Bomb;
using GameEntities.Bonuses.BonusBehaviour.Life;
using GameEntities.Bonuses.BonusBehaviour.Platform;
using GameEntities.Bonuses.Enumerations;
using GameEntities.Bonuses.Interfaces;
using UnityEngine;

namespace GameComponents.Bonus
{
    public class BonusBehaviourFactory
    {
        public IBonusBehaviour CreateBehaviour(BonusType type, Vector2 position)
        {
            switch (type)
            {
                case BonusType.BallVelocityUp:
                    return new BallVelocityBonusBehaviour(ValueModifer.Increase);
                case BonusType.BallVelocityDown:
                    return new BallVelocityBonusBehaviour(ValueModifer.Decrease);
                case BonusType.PlatformSpeedUp:
                    return new PlatformSpeedBonusBehaviour(ValueModifer.Increase);
                case BonusType.PlatformSpeedDown:
                    return new PlatformSpeedBonusBehaviour(ValueModifer.Decrease);
                case BonusType.PlatformSizeUp:
                    return new PlatformSizeBonusBehaviour(ValueModifer.Increase);
                case BonusType.PlatformSizeDown:
                    return new PlatformSizeBonusBehaviour(ValueModifer.Decrease);
                case BonusType.RageBall:
                    return new RageBallBonusBehaviour();
                case BonusType.ExtraBall:
                    return new ExtraBallBonusBehaviour(position);
                case BonusType.LifeDecreaseBonus:
                    return new LifeBonusBehaviour(ValueModifer.Decrease);
                case BonusType.LifeIncreaseBonus:
                    return new LifeBonusBehaviour(ValueModifer.Increase);
                case BonusType.HorizontalBombBonus:
                    return new DirectionBombBonusBehaviour(position, BombBonusDirection.Horizontal);
                case BonusType.VerticalBombBonus:
                    return new DirectionBombBonusBehaviour(position, BombBonusDirection.Vertical);
            }

            return null;
        }
    }
}