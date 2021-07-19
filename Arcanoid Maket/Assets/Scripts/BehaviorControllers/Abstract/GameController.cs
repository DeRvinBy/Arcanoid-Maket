using UnityEngine;

namespace BehaviorControllers.Abstract
{
    public abstract class GameController : MonoBehaviour
    {
        public virtual void Initialize(ControllersManager controllersManager) {}    
    }
}