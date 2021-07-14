using System;
using Project.Scripts.Animations.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.UI.UIElements
{
    public class EventButton : MonoBehaviour
    {
        public event Action OnButtonPressed;

        [SerializeField]
        private ButtonAnimation _animation;
        
        [SerializeField]
        private Button _button;

        public void Initialize()
        {
            _animation.Initialize();
            _button.onClick.AddListener(OnClick);
        }

        public void Enable()
        {
            _button.interactable = true;
        }
        
        public void Disable()
        {
            _button.interactable = false;
        }
        
        private void OnClick()
        {
            _button.interactable = false;
            _animation.PlayAnimation(() => _button.interactable = true);
            OnButtonPressed?.Invoke();
        }
    }
}