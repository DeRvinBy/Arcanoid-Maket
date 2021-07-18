using Scripts.Utils.EventSystem;

namespace Scripts.Utils.Localization.Interfaces
{
    public interface ILanguageChangedEvent : IGlobalSubscriber
    {
        void OnLanguageChanged();
    }
}