using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.GameEvents.UIEvents
{
    public interface IPacksUIHandler : IGlobalSubscriber
    {
        void OnStartChoosePack();
        void OnPackChoose();
        void OnCancelChoosePack();
    }
}