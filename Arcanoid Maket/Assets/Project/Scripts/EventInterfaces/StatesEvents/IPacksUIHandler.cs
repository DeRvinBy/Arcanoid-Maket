using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.StatesEvents
{
    public interface IPacksUIHandler : IGlobalSubscriber
    {
        void OnStartChoosePack();
        void OnPackChoose(string packKey);
        void OnCancelChoosePack();
    }
}