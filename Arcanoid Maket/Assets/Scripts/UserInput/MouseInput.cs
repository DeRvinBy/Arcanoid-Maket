using Scripts.EventInterfaces.Input;
using Scripts.Utils.EventSystem;
using UnityEngine;

namespace Scripts.UserInput
{
    public class MouseInput : MonoBehaviour, IInputEnabledHandler
    {
        private const int MouseButton = 0;

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
                EventBus.RaiseEvent<IMoveToTargetHandler>(a => a.OnMoveToMouse(Input.mousePosition));
            }
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