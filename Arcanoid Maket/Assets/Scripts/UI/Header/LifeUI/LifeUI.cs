using System.Collections.Generic;
using Scripts.GameSettings.LifeSettings;
using Scripts.Utils.ObjectPool;
using UnityEngine;

namespace Scripts.UI.Header.LifeUI
{
    public class LifeUI : MonoBehaviour
    {
        private List<LifeImageUI> _lifeImages;

        public void CreateLifeContainers(LifeSettings settings)
        {
            _lifeImages = new List<LifeImageUI>();

            for (int i = 0; i < settings.StartLifeCount; i++)
            {
                var imageUI = PoolsManager.Instance.GetObject<LifeImageUI>(Vector3.zero, transform);
                imageUI.transform.localScale = Vector3.one;
                _lifeImages.Add(imageUI);
            }
        }

        public void UpdateLifeCount(int lifeCount)
        {
            for (int i = 0; i < _lifeImages.Count; i++)
            {
                if(i < lifeCount)
                {
                    _lifeImages[i].ShowLife();
                }
                else
                {
                    _lifeImages[i].HideLife();
                }
            }
        }
    }
}