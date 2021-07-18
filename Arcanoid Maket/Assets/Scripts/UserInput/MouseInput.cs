using Scripts.EventInterfaces.Input;
using Scripts.Utils.EventSystem;
using UnityEngine;

namespace Scripts.UserInput
{
    public class MouseInput : MonoBehaviour
    {
        private const int MouseButton = 0;

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
                EventBus.RaiseEvent<IPushBallHandler>(a => a.OnPush());
                _isInputActive = false;
                return;
            }

            if (_isInputActive)
            {
                EventBus.RaiseEvent<IMoveToTargetHandler>(a => a.OnMoveToMouse(Input.mousePosition));
            }
        }
    }
}