using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.EventInterfaces.Input
{
    public interface IMoveToTargetHandler : IGlobalSubscriber
    {
        void OnMoveToMouse(Vector3 position);
    }
}