using GameEntities.Ball;
using GameEntities.Bonuses.Enumerations;
using MyLibrary.EventSystem;

namespace EventInterfaces.BonusEvents
{
    public interface IBallVelocityBonusHandler : IGlobalSubscriber
    {
        void UpdateVelocityForNewBall(BallEntity ball);
        void ActivateVelocityBonus(ValueModifer modifer);
    }
}