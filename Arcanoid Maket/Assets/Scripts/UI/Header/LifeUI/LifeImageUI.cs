using Scripts.Utils.ObjectPool.Abstract;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Header.LifeUI
{
    public class LifeImageUI : PoolObject
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