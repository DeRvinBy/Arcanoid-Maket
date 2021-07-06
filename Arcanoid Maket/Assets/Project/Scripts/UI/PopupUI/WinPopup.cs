using Project.Scripts.UI.PopupUI.Abstract;
using UnityEngine;

namespace Project.Scripts.UI.PopupUI
{
    public class WinPopup : Popup
    {
        public override void StartPopup()
        {
            Debug.Log("Start Win Popup");
        }
    }
}