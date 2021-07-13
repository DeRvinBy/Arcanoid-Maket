using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.UI.PopupUI.Abstract;
using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.UI.PopupUI
{
    public class LosePopup : Popup
    {
        public void OnRestartButtonPressed()
        {
            EventBus.RaiseEvent<IStartGameHandler>(a => a.OnStartGameProcess());
        }
    }
}