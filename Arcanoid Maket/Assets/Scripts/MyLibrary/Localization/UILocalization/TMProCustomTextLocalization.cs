namespace MyLibrary.Localization.UILocalization
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