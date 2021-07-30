using MyLibrary.EventSystem;
using MyLibrary.Localization.Interfaces;
using TMPro;
using UnityEngine;

namespace MyLibrary.Localization.UI
{
    public class TMProTextLocalization : MonoBehaviour, ILanguageChangedEvent
    {
        [SerializeField]
        protected TMP_Text _tmpText;

        [SerializeField]
        protected string _translationName = "";

        private void OnValidate()
        {
            _tmpText.text = _translationName;
        }

        private void OnEnable()
        {
            EventBus.Subscribe(this);
            OnLanguageChanged();
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }

        public virtual void OnLanguageChanged()
        {
            _tmpText.text = LocalizationManager.Instance.GetCurrentTranslation(_translationName);
        }
    }
}