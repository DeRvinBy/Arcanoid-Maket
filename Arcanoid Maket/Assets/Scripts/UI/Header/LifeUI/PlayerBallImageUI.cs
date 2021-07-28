using MyLibrary.ObjectPool.Abstract;
using MyLibrary.UI.UIPool;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Header.LifeUI
{
    public class PlayerBallImageUI : UIElementPoolObject
    {
        [SerializeField]
        private Image _icon;
        
        public void ShowLife()
        {
            _icon.enabled = true;
        }

        public void HideLife()
        {
            _icon.enabled = false;
        }
    }
}