using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.Utils.Localization.Interfaces
{
    public interface ILanguageChangedEvent : IGlobalSubscriber
    {
        void OnLanguageChanged();
    }
}