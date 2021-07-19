using UnityEngine;

namespace Scripts.BehaviorControllers.Abstract
{
    public abstract class GameController : MonoBehaviour
    {
        public virtual void Initialize(ControllersManager controllersManager) {}    
    }
}