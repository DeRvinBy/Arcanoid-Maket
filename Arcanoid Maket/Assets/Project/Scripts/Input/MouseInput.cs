using System;
using UnityEngine;

namespace Project.Scripts.Input
{
    public class MouseInput : MonoBehaviour
    {
        private const int MouseButton = 0;
        
        public event Action<Vector2> OnMousePositionUpdated;
        public event Action OnMouseButtonUp;

        private bool _isInputActive;
        
        private void Update()
        {
            if (UnityEngine.Input.GetMouseButtonDown(MouseButton))
            {
                _isInputActive = true;
                return;
            }

            if (UnityEngine.Input.GetMouseButtonUp(MouseButton))
            {
                OnMouseButtonUp?.Invoke();
                _isInputActive = false;
                return;
            }

            if (_isInputActive)
            {
                UpdateMouseDeltaPosition();
            }
        }

        private void UpdateMouseDeltaPosition()
        {
            OnMousePositionUpdated?.Invoke(UnityEngine.Input.mousePosition);
        }
    }
}