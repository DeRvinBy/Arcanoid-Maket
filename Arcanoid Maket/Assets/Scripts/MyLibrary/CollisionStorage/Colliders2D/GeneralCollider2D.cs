using UnityEngine;

namespace MyLibrary.CollisionStorage.Colliders2D
{
    public class GeneralCollider2D : MonoBehaviour 
    {
        [SerializeField]
        protected Collider2D _collider;

        public virtual void RegisterCollider<T>(T monoBehaviour) where T : MonoBehaviour
        {
            CollisionStorage2D.Instance.RegisterCollider(_collider, monoBehaviour);
        }
        
        public virtual void UnregisterCollider<T>(T monoBehaviour) where T : MonoBehaviour
        {
            if (CollisionStorage2D.IsAlive)
            {
                CollisionStorage2D.Instance.UnregisterCollider(_collider, monoBehaviour);
            }
        }
    }
}