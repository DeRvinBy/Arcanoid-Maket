using Scripts.Utils.EventSystem;

namespace Scripts.EventInterfaces.StatesEvents
{
    public interface IPacksChoosingHandler : IGlobalSubscriber
    {
        void OnStartChoosePack();
        void OnPackChoose(string packKey);
        void OnCancelChoosePack();
    }
}