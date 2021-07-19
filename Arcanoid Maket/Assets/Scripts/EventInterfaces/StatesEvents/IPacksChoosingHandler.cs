using Scripts.Utils.EventSystem;

namespace EventInterfaces.StatesEvents
{
    public interface IPacksChoosingHandler : IGlobalSubscriber
    {
        void OnStartChoosePack();
        void OnPackChoose(string packKey);
        void OnCancelChoosePack();
    }
}