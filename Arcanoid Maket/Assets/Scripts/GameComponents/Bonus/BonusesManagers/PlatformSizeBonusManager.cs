using BehaviorControllers.EntitiesControllers;
using EventInterfaces.BonusEvents;
using GameComponents.Bonus.Abstract;
using GameComponents.Bonus.Effects;
using GameEntities.Bonuses.Enumerations;
using MyLibrary.EventSystem;
using UnityEngine;

namespace GameComponents.Bonus.BonusesManagers
{
    public class PlatformSizeBonusManager : AbstractBonusManager, IPlatformSizeBonusHandler
    {
        [SerializeField]
        private PlatformController _platform;
        
        [SerializeField]
        private VariableValueEffect _bonusEffect;
        
        private void OnEnable()
        {
            EventBus.Subscribe(this);
            _bonusEffect.OnValueChanged += UpdatePlatformSize;
        }

        private void OnDisable()
        {
            EventBus.Subscribe(this);
            _bonusEffect.OnValueChanged -= UpdatePlatformSize;
        }
        
        public void ActivateSizeBonus(ValueModifer modifer)
        {
            _bonusEffect.ActivateEffect(modifer);
        }
        
        private void UpdatePlatformSize(float value)
        {
            _platform.SetAdditionalSize(value);
        }

        public override void OnPrepareGame()
        {
            _bonusEffect.StopEffect();
        }
    }
}