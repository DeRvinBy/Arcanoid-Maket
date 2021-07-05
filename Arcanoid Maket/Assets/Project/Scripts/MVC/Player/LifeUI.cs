using System.Collections.Generic;
using Project.Scripts.GameSettings.PlayerSettings;
using Project.Scripts.MVC.Player.GameComponents;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.MVC.Player
{
    public class LifeUI : MonoBehaviour
    {
        [SerializeField]
        private LayoutGroup _layoutGroup;

        private RectTransform _rectTransform;
        private IList<LifeImageUI> _lifeImages;

        public void Initialize(LifeSettings settings)
        {
            _rectTransform = (RectTransform) transform;
            CreateLifeContainers(settings);
        }

        private void UpdateLayoutGroupByLifeCount()
        {
            
        }
        
        private void CreateLifeContainers(LifeSettings settings)
        {
            _lifeImages = new List<LifeImageUI>();

            for (int i = 0; i < settings.StartLifeCount; i++)
            {
                var imageUI = Instantiate(settings.Prefab, transform);
                _lifeImages.Add(imageUI);
            }
        }

        public void SetLifeCountInUI(int lifeCount)
        {
            for (int i = 0; i < _lifeImages.Count; i++)
            {
                if (i < lifeCount)
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