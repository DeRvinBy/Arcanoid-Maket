using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.UI.PopupUI.Abstract;
using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.UI.PopupUI
{
    public class LosePopup : Popup
    {
        public override void StartPopup()
        {
            
        }
        
        public void OnRestartButtonPressed()
        {
            EventBus.RaiseEvent<IStartGameplayHandler>(a => a.OnStartGameProcess());
        }
    }
}