namespace MyLibrary.Localization.UI
{
    public class TMProCustomTextLocalization : TMProTextLocalization
    {
        public void SetTranslationName(string translationName)
        {
            _translationName = translationName;
            OnLanguageChanged();
        }
    }
}