using BehaviorControllers.EntitiesControllers;
using EventInterfaces.BonusEvents;
using GameComponents.Bonus.Abstract;
using GameComponents.Bonus.Effects;
using GameEntities.Bonuses.Enumerations;
using GameSettings.GameBonusSettings.BonusesSettings;
using MyLibrary.EventSystem;
using UnityEngine;

namespace GameComponents.Bonus.BonusesManagers
{
    public class PlatformSpeedBonusManager : AbstractBonusManager, IPlatformSpeedBonusHandler
    {
        [SerializeField]
        private PlatformController _platform;
        
        [SerializeField]
        private VariableValueEffect _bonusEffect;

        private void OnEnable()
        {
            EventBus.Subscribe(this);
            _bonusEffect.OnValueChanged += UpdatePlatformSpeed;
        }

        private void OnDisable()
        {
            EventBus.Subscribe(this);
            _bonusEffect.OnValueChanged -= UpdatePlatformSpeed;
        }
        
        public void ActivateSpeedBonus(ValueModifer modifer)
        {
            _bonusEffect.ActivateEffect(modifer);
        }
        
        private void UpdatePlatformSpeed(float value)
        {
            _platform.SetAdditionalSpeed(value);
        }
        
        public override void OnPrepareGame()
        {
            _bonusEffect.StopEffect();
        }
    }
}