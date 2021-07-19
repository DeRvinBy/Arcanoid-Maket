using EventInterfaces.FieldEvents;
using EventInterfaces.Input;
using Library.EventSystem;
using UnityEngine;

namespace UserInput
{
    public class MouseInput : MonoBehaviour, IInputEnabledHandler, IFieldPropertiesHandler
    {
        private const int MouseButton = 0;

        private float _availableScreenHeight;
        private bool _isInputActive;
        private bool _isInputOccur;

        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }
        
        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }

        private void Update()
        {
            if (!_isInputActive) return;
            
            if (Input.GetMouseButtonDown(MouseButton))
            {
                _isInputOccur = true;
                return;
            }

            if (_isInputOccur && Input.GetMouseButtonUp(MouseButton))
            {
                EventBus.RaiseEvent<IPushBallHandler>(a => a.OnPush());
                _isInputOccur = false;
                return;
            }

            if (_isInputOccur)
            {
                UpdateMousePosition();
            }
        }

        private void UpdateMousePosition()
        {
            var position = Input.mousePosition;
            if (position.y < _availableScreenHeight)
            {
                EventBus.RaiseEvent<IMoveToTargetHandler>(a => a.OnMoveToMouse(position));
            }
        }

        public void OnFieldScreenHeightSetup(float height)
        {
            _availableScreenHeight = height;
        }
        
        public void OnEnableInput()
        {
            _isInputActive = true;
        }

        public void OnDisableInput()
        {
            _isInputActive = false;
            _isInputOccur = false;
        }
    }
}