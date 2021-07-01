using Project.Scripts.Utils.EventSystem;
using Project.Scripts.Utils.Localization.Interfaces;
using TMPro;
using UnityEngine;

namespace Project.Scripts.Utils.Localization.UILocalization
{
    public class TextMeshProLocalization : MonoBehaviour, ILanguageChangedEvent
    {
        [SerializeField]
        private TMP_Text _tmpText = null;

        [SerializeField]
        private string translationName = "";

        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }

        public void OnLanguageChanged()
        {
            _tmpText.text = LocalizationManager.GetCurrentTranslation(translationName);
        }
    }
}