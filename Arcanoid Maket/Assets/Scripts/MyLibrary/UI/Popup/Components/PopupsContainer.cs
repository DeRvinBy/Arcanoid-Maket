using MyLibrary.UI.UIPool;
using UnityEngine;

namespace MyLibrary.UI.Popup.Components
{
    public class PopupsContainer : UIElementPoolObject
    {
        [SerializeField]
        private PopupsLocker _popupsLocker;

        public PopupsLocker PopupsLocker => _popupsLocker;
    }
}