using System;
using MyLibrary.UI.Button.Abstract;
using UnityEngine;

namespace MyLibrary.UI.Button
{
    public class EventButton : MonoBehaviour
    {
        public event Action OnButtonPressed;

        [SerializeField]
        private AbstractButtonAnimation _animation;
        
        [SerializeField]
        private UnityEngine.UI.Button _button;

        public void Start()
        {
            _animation.SetupAnimation();
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