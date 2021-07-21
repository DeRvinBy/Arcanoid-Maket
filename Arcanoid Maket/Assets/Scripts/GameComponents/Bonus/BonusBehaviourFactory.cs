using GameEntities.Bonuses.Behaviour;
using GameEntities.Bonuses.Enumerations;
using GameEntities.Bonuses.Interfaces;
using GameSettings.GameBonusSettings;

namespace GameComponents.Bonus
{
    public class BonusBehaviourFactory
    {
        private BonusesSettingsContainer _settings;

        public BonusBehaviourFactory(BonusesSettingsContainer settings)
        {
            _settings = settings;
        }

        public IBonusBehaviour CreateBehaviour(BonusType type)
        {
            switch (type)
            {
                case BonusType.BallSpeedUp:
                    return new BallSpeedBonusBehaviour(_settings.BallSpeedSettings.SpeedVariableValue,
                        _settings.BallSpeedSettings.TimeOfEffect);
                case BonusType.BallSpeedDown:
                    return new BallSpeedBonusBehaviour(-_settings.BallSpeedSettings.SpeedVariableValue,
                        _settings.BallSpeedSettings.TimeOfEffect);
            }

            return null;
        }
    }
}