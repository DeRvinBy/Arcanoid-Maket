using System;
using UnityEngine;

namespace Project.Scripts.MVC.Platform
{
    public class UserInput : MonoBehaviour
    {
        private const int MouseButton = 0;
        
        public event Action<Vector2> OnMousePositionUpdated;

        private bool _isInputActive;
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(MouseButton))
            {
                _isInputActive = true;
                return;
            }

            if (Input.GetMouseButtonUp(MouseButton))
            {
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
            OnMousePositionUpdated?.Invoke(Input.mousePosition);
        }
    }
}