using Scripts.Utils.EventSystem;
using UnityEngine;

namespace EventInterfaces.Input
{
    public interface IMoveToTargetHandler : IGlobalSubscriber
    {
        void OnMoveToMouse(Vector3 position);
    }
}