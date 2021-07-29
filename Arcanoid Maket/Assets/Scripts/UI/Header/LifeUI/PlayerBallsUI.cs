using System.Collections.Generic;
using GameSettings.LifeSettings;
using MyLibrary.ObjectPool;
using UnityEngine;

namespace UI.Header.LifeUI
{
    public class PlayerBallsUI : MonoBehaviour
    {
        private List<PlayerBallImageUI> _lifeImages;

        public void CreatePlayerBallImageContainers(PlayerBallsSettings settings)
        {
            _lifeImages = new List<PlayerBallImageUI>();

            for (int i = 0; i < settings.StartBallsCount; i++)
            {
                var imageUI = PoolsManager.Instance.GetObject<PlayerBallImageUI>(Vector3.zero, transform);
                imageUI.transform.localScale = Vector3.one;
                _lifeImages.Add(imageUI);
            }
        }

        public void UpdatePlayerBallCount(int ballCount)
        {
            for (int i = 0; i < _lifeImages.Count; i++)
            {
                if(i < ballCount)
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