using MyLibrary.EventSystem;

namespace MyLibrary.Localization.Interfaces
{
    public interface ILanguageChangedEvent : IGlobalSubscriber
    {
        void OnLanguageChanged();
    }
}