using BehaviorControllers.EntitiesControllers;
using EventInterfaces.BonusEvents.Platform;
using EventInterfaces.GameEvents;
using EventInterfaces.StatesEvents;
using GameComponents.Bonus.Effects;
using GameEntities.Bonuses.Enumerations;
using MyLibrary.EventSystem;
using UnityEngine;

namespace GameComponents.Bonus.BonusesManagers.Platform
{
    public class PlatformSizeBonusManager : MonoBehaviour, IPlatformSizeBonusHandler, IPrepareGameplayHandler, IContinueGameHandler
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
        
        public void OnActivateSizeBonus(ValueModifer modifer)
        {
            _bonusEffect.ActivateEffect(modifer);
        }
        
        private void UpdatePlatformSize(float value)
        {
            _platform.SetAdditionalSize(value);
        }

        public void OnPrepareGame()
        {
            _bonusEffect.StopEffect();
        }

        public void OnContinueGame()
        {
            _bonusEffect.StopEffect();
        }
    }
}