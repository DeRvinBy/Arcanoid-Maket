using Scripts.Utils.EventSystem;
using UnityEngine;

namespace Scripts.EventInterfaces.Input
{
    public interface IMoveToTargetHandler : IGlobalSubscriber
    {
        void OnMoveToMouse(Vector3 position);
    }
}